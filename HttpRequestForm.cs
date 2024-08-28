using System.Text;
using System.Net.Http.Headers;
using System.Runtime;
using ArticleJsonFetch.Models;
using System.Windows.Forms;
using ArticleJsonFetch.DataModels;
using System.Collections.Immutable;
using System.Xml;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Net.Http.Json;
using System.Net;
using System.Net.NetworkInformation;
using ArticleJsonFetch.Services;
using System;
using System.Net.Http;
using HttpRequest.Services;

namespace ArticleJsonFetch
{
    public partial class HTTPRequest : Form
    {
        private Control _UrlControlExceptioned = new Control();
        private Control _RichText1ControlExceptioned = new Control();
        private bool richTxtBoxToolTipIsExceptionMessage = false;
        private bool urlToolTipIsExceptionMessage = false;
        private DataKind richTextDataKind = DataKind.NONE;
        public bool HttpRequestTesting = true;
        public bool HttpRequestTestTryDns = false;
        public bool MainPanel1Collapsed = false;
        public int MinimumViewableSize = 315;
        private HRFDataExtraction HRFDataExtraction = new HRFDataExtraction();
        private RequestEngine RequestEngine;
        private bool DisableDnsTesting = false;
        private string bodyText = string.Empty;


        enum DataKind
        {
            NONE,
            STRING,
            JSON,
            HEADERS,
            HTML,
        }

        public HTTPRequest()
        {
            _UrlControlExceptioned.Visible = false;
            _RichText1ControlExceptioned.Visible = false;
            RequestEngine = new RequestEngine(HRFDataExtraction);

            InitializeComponent();
        }
        private void urlTextBox_TextChanged(object sender, EventArgs e)
        {
            var validUrl = @"Enter a valid url in format http(s)://domain:port/";

            // Change tooltip back to normal
            if (_controlException != null && _UrlControlExceptioned != null)
                _controlException.returnControlExceptionToolTip(ref urlToolTip, ref _UrlControlExceptioned, validUrl);
            else if (_controlException != null)
            {
                _UrlControlExceptioned = txtboxUrl;
                _controlException.returnControlExceptionToolTip(ref urlToolTip, ref _UrlControlExceptioned, validUrl);
            }
        }

        private void methodCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var urlCheckMethod = methodCombo.Text;

            HRFDataExtraction.SetRequestMethod(methodCombo.Text);

            if (String.Equals(urlCheckMethod, "GET") | String.Equals(urlCheckMethod, "HEAD"))
            {
                bodyText = richtxtBody.Text;
                richtxtBody.Text = string.Empty;
                richtxtBody.ReadOnly = true;
            }
            else
            {
                if (HRFDataExtraction.RequestData.MessageBody != null)
                    richtxtBody.Text = bodyText;
                richtxtBody.ReadOnly = false;
            }
        }

        private void contentTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            HRFDataExtraction.SetRequestMessageBody(richtxtBody.Text, contentTypeComboBox.Text);
        }

        private void richtxtBody_TextChanged(object sender, EventArgs e)
        {
            HRFDataExtraction.SetRequestMessageBody(richtxtBody.Text, contentTypeComboBox.Text);
        }

        private async void btnFetch_Click(object sender, EventArgs e)
        {
            SetupBaseUrlforFetch();
            //SetupMessageBodyforFetch();
            SetupResponseBodyBtnOptions();

            if (urlToolTipIsExceptionMessage)
            {//reset rich text box and tooltip
             //stop the fetch continuing because of the bad url
                richTxtData.Text = "";
                var blankMessage = " ";
                _controlException.returnRichTextToolTip(ref dataToolTip, ref richTxtData, blankMessage);
                richTxtBoxToolTipIsExceptionMessage = false;
                urlToolTipIsExceptionMessage = false;

                return;
            }

            var responseDataText = await RequestEngine.CallDataFetch(HRFDataExtraction);
            if (responseDataText.isMessageException == true)
            {
                //logic for handling exception
                //if message...
                //richTxtData.ForeColor = System.Drawing.Color.Red; is NotSupportedException
                //richTxtData.ForeColor = System.Drawing.Color.DarkViolet;
                SetRichTxtBoxException(responseDataText.responseData);

                if (DisableDnsTesting)
                {
                    responseDataText.responseData += "\n\nDNS testing is disabled. Please check your network connection and try again.\n";
                }
                if (responseDataText.isDnsTestingCandidate)
                {
                    var httpExceptionRequest = RequestEngine.LastestException;
                    DnsTestingOnException(httpExceptionRequest!, RequestEngine.BaseAddress!, responseDataText.responseData);
                }
            }
            else
            {
                richTxtBoxToolTipIsExceptionMessage = false;
                if (string.IsNullOrWhiteSpace(responseDataText.responseData))
                {
                    responseDataText.responseData = "No data returned from the fetch.";
                    SetRichTxtBoxException("No data returned from the fetch.");
                }
            }
            //Check 
            bool isNewBtn = CheckDataKindIsJson(responseDataText.responseData);
            if (isNewBtn)
            {
                btnJSON.Enabled = true;
                flowLayoutPanel1.Controls.Add(btnJSON);
            }
            richTxtData.Text = responseDataText.responseData;

            // Change tooltip back to normal
            var RequestDataLength = richTxtData.Text.Length;
            string dataToolTipCaption = $"Data Length is: {RequestDataLength.ToString()}\nOther: 100!";

            if (!richTxtBoxToolTipIsExceptionMessage)
                _controlException.createRichTextToolTip(ref dataToolTip, ref richTxtData, dataToolTipCaption, "info");
        }

        private void SetRichTxtBoxException(string caption)
        {
            _controlException.createRichTextToolTip(ref dataToolTip, ref richTxtData, caption, "error");
            richTxtData.ForeColor = System.Drawing.Color.Red;
            richTxtBoxToolTipIsExceptionMessage = true;
        }

        private void SetupBaseUrlforFetch()
        {
            if (String.IsNullOrWhiteSpace(txtboxUrl.Text))
            {
                return;
            }
            try
            {
                HRFDataExtraction.SetRequestBaseAddress(txtboxUrl.Text);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("\nInvalid Operation Caught!");
                Console.WriteLine("Message: {0} ", e.Message);
                richTxtData.Text = e.Message;
                richTxtData.ForeColor = System.Drawing.Color.DarkViolet;
                urlToolTipIsExceptionMessage = true;
            }
            catch (Exception e) when (e is System.UriFormatException || e is ArgumentNullException)
            {
                Console.WriteLine("UriFormatException Caught!");
                Console.WriteLine("Message: {0} ", e.Message);
                _UrlControlExceptioned = txtboxUrl;
                _controlException.createControlExceptionToolTip(ref urlToolTip, ref _UrlControlExceptioned, e.Message, "error");
                urlToolTipIsExceptionMessage = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Caught!");
                Console.WriteLine("Message: {0}\n{1}", e.Message, e.StackTrace);
                urlToolTipIsExceptionMessage = true;
            }
        }

        private void SetupMessageBodyforFetch()
        {
            //Debug.WriteLine(richtxtBody.Text.ToString());
            //var bodyStr = richtxtBody.Text.ToString();
            //if (CheckDataKindIsJson(bodyStr))
            //{
            //    Debug.WriteLine("True");
            //    bodyStr = JsonConvert.ToString(bodyStr);
            //}
            //HRFDataExtraction.SetRequestBody(bodyStr);
            HRFDataExtraction.SetRequestMessageBody(richtxtBody.Text, contentTypeComboBox.Text);
        }

        private void SetupResponseBodyBtnOptions()
        {
            //reset JSON button display for use after a successful fetch
            btnJSON.Enabled = false;
            flowLayoutPanel1.Controls.Remove(btnJSON);
        }

        private string DnsTestingOnException(System.Exception ex, Uri baseAddress, string responseData)
        {
            //Begin DNS test

            HttpRequestTesting = true;
            if (HttpRequestTesting)
            {
                btnFetch.Enabled = false;
                txtboxUrl.Enabled = false;
                methodCombo.Enabled = false;
                contentTypeComboBox.Enabled = false;
                richtxtBody.Enabled = false;
                btnTest.Enabled = true;
                btnTest.Visible = true;
                btnCancel.Enabled = true;
                btnCancel.Visible = true;
                flowLayoutPanel2.Controls.Add(btnTest);
                flowLayoutPanel2.Controls.Add(btnCancel);
            }

            bool TriedDnsTest = false;
            string DnsTestResultMessage = string.Empty;
            richTxtData.Text = responseData + "\n";
            richTxtData.Text += "There's been an error trying that fetch. Do you want to test DNS ( Test (Alt + T)/Cancel (Alt + N) )?\n";

            do
            {
                //insert ping option buttons.
                while (!HttpRequestTestTryDns & HttpRequestTesting)
                {
                    Application.DoEvents(); // Process all Windows messages
                    if (richTxtData.Text == "")
                    {
                        richTxtData.Text = "Please press Test (Alt + T) or Cancel (Alt + N) for DNS test.\n";
                    }
                }
                if (HttpRequestTestTryDns)
                {
                    DnsTestResultMessage = string.Empty;
                    DnsTestResultMessage += ExceptionTester.DnsTest(baseAddress);

                    HttpRequestTestTryDns = false;
                    richTxtData.Text += DnsTestResultMessage;
                }

                if (!HttpRequestTesting)
                {
                    btnFetch.Enabled = true;
                    txtboxUrl.Enabled = true;
                    methodCombo.Enabled = true;
                    contentTypeComboBox.Enabled = true;
                    richtxtBody.Enabled = true;
                    btnTest.Enabled = false;
                    btnTest.Visible = false;
                    btnCancel.Enabled = false;
                    btnCancel.Visible = false;
                    flowLayoutPanel2.Controls.Remove(btnTest);
                    flowLayoutPanel2.Controls.Remove(btnCancel);
                }
            } while (HttpRequestTesting);
            if (TriedDnsTest)
                return richTxtData.Text += DnsTestResultMessage;
            else
            {
                return ex.Message;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnToJSON_Click(object sender, EventArgs e)
        {
            var bodyResponseText = richTxtData.Text;

            if (richTextDataKind == DataKind.JSON & !string.IsNullOrWhiteSpace(bodyResponseText))
            {
                HttpJsonSerializer serializer = new HttpJsonSerializer();
                serializer.DeserializeToJson(ref bodyResponseText);
                if (serializer.isJson)
                {
                    richTxtData.Text = serializer.obj.ToString();
                }
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, (Object)richTxtData.Text);
        }

        private void btnPing_Click(object sender, EventArgs e)
        {
            HttpRequestTestTryDns = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            HttpRequestTesting = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            richTxtData.Text = string.Empty;
        }

        private void btnFull_Click(object sender, EventArgs e)
        {
            CollapseMainPanel1();
        }

        private void CollapseMainPanel1()
        {
            MainPanel1Collapsed = MainPanel1Collapsed ? false : true;
            splitContainerMain.Panel1Collapsed = MainPanel1Collapsed;
            if (MainPanel1Collapsed)
            {
                btnFull.Text = "FETCH";
            }
            else
            {
                btnFull.Text = "FULL";
                if (this.Height < MinimumViewableSize)
                {
                    this.Height = MinimumViewableSize;
                }
                if (this.Height >= MinimumViewableSize)
                {
                    splitContainerMain.SplitterDistance = 180;
                }
            }
        }

        private void HTTPRequest_ResizeEnd(object sender, EventArgs e)
        {
            if (this.Size.Height < MinimumViewableSize & MainPanel1Collapsed == false)
            {
                CollapseMainPanel1();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the currently active control
            Control activeControl = this.ActiveControl;

            // Perform actions on the active control
            if (activeControl != null)
            {
                // Example: Cut text if the active control is a TextBox
                if (activeControl is TextBox textBox)
                {
                    textBox.Cut();
                }
                if (activeControl is RichTextBox richTextBox)
                {
                    richTextBox.Cut();
                }
            }
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            DisableDnsTesting = DisableDnsTesting ? false : true;
        }

        private void toolStripMenuItemShowContentHeaders_Click(object sender, EventArgs e)
        {
            RequestEngine.ToggleShowContentHeaders();
        }

        private bool CheckDataKindIsJson(string ResponseData)
        {
            HttpJsonSerializer responseDataJsonSerializer = new();
            try
            {
                responseDataJsonSerializer.DeserializeToJson(ref ResponseData);
            }
            catch (Exception e)
            {
                Debug.Write("\nException caught in fetch!");
                Debug.Write("Message: {0} ", e.Message);
            }

            if (responseDataJsonSerializer.isJson)
            {
                richTextDataKind = DataKind.JSON;
                return true;
            }
            else
            {
                return false;
            }
        }

        
    }
}
