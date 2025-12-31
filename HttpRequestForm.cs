//--Copyright (c) 2024-2026 Robert A. Howell

using System;
using System.Windows.Forms;
using HttpRequest.Services;

namespace HttpRequest
{
    internal partial class HTTPRequest : Form
    {
        private Control _urlControlExceptioned = new Control();
        private Control _richText1ControlExceptioned = new Control();
        private bool _richTxtBoxToolTipIsExceptionMessage = false;
        private string _bodyText = string.Empty;
        public bool HttpRequestTesting = true;
        public bool HttpRequestTestTryDns = false;
        public bool MainPanel1Collapsed = false;
        public string DnsTestResultMessage = string.Empty;
        public int MinimumViewableSize = 315;
        private HRFDataExtraction _HRFDataExtraction = new HRFDataExtraction();  //For data plane use (future)
        private RequestEngine _RequestEngine;
        private bool _DisableDnsTesting = false;


        public HTTPRequest()
        {
            _urlControlExceptioned.Visible = false;
            _richText1ControlExceptioned.Visible = false;
            _RequestEngine = new RequestEngine(_HRFDataExtraction);
            
            InitializeComponent();
        }
        private void urlTextBox_TextChanged(object sender, EventArgs e)
        {
            //Logic redacted for project example
        }

        private void methodCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var urlCheckMethod = methodCombo.Text;

            _HRFDataExtraction.SetRequestMethod(methodCombo.Text);

            if (String.Equals(urlCheckMethod, "GET"))
            {
                _bodyText = richtxtBody.Text;
                richtxtBody.Text = string.Empty;
                richtxtBody.ReadOnly = true;
            }
            else
            {
                if (_HRFDataExtraction.RequestData.MessageBody != null)
                    richtxtBody.Text = _bodyText;
                richtxtBody.ReadOnly = false;
            }
        }

        private void contentTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _HRFDataExtraction.SetRequestMessageBody(richtxtBody.Text, string.Empty);
        }

        private void richtxtBody_TextChanged(object sender, EventArgs e)
        {
            _HRFDataExtraction.SetRequestMessageBody(richtxtBody.Text, string.Empty);
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
                richtxtBody.Enabled = false;
                btnTest.Enabled = true;
                btnTest.Visible = true;
                btnCancel.Enabled = true;
                btnCancel.Visible = true;
                flowLayoutPanel2.Controls.Add(btnTest);
                flowLayoutPanel2.Controls.Add(btnCancel);
            }

            bool TriedDnsTest = false;
            DnsTestResultMessage = string.Empty;
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

        private void SetRichTxtBoxException(string caption)
        {
            //Logic redacted for project example
        }

        private async void btnFetch_Click(object sender, EventArgs e)
        {
            SetupBaseUrlforFetch();
            SetupResponseBodyBtnOptions();
            //Logic redacted for project example

            var responseDataText = await _RequestEngine.CallDataFetch(_HRFDataExtraction);
            if (responseDataText.isMessageException == true)
            {
                if (_DisableDnsTesting)
                {
                    responseDataText.responseData += "\n\nDNS testing is disabled. Please check your network connection and try again.\n";
                }

                if (responseDataText.isDnsTestingCandidate)
                {
                    var httpExceptionRequest = _RequestEngine.LastestException;
                    DnsTestingOnException(httpExceptionRequest!, _RequestEngine.BaseAddress!, responseDataText.responseData);
                }
            }
            else
            {
                _richTxtBoxToolTipIsExceptionMessage = false;
                if (string.IsNullOrWhiteSpace(responseDataText.responseData))
                {
                    responseDataText.responseData = "No data returned from the fetch.";
                    SetRichTxtBoxException("No data returned from the fetch.");
                }
            }
            //Logic redacted for project example
            richTxtData.Text = responseDataText.responseData;

            // Change tooltip back to normal
            var RequestDataLength = richTxtData.Text.Length;
            string dataToolTipCaption = $"Data Length is: {RequestDataLength.ToString()}\nOther: 100!";

            if (!_richTxtBoxToolTipIsExceptionMessage)
                _controlException.createRichTextToolTip(ref dataToolTip, ref richTxtData, dataToolTipCaption, "info");
        }

        private void SetupBaseUrlforFetch()
        {
            if (String.IsNullOrWhiteSpace(txtboxUrl.Text))
            {
                return;
            }
            try
            {
                _HRFDataExtraction.SetRequestBaseAddress(txtboxUrl.Text);
            }
            catch (Exception e) when (e is System.UriFormatException || e is ArgumentNullException)
            {
                Console.WriteLine("UriFormatException Caught!");
                Console.WriteLine("Message: {0} ", e.Message);
                //Logic redacted for project example
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Caught!");
                Console.WriteLine("Message: {0}\n{1}", e.Message, e.StackTrace);
            }
        }

        private void SetupResponseBodyBtnOptions()
        {
            //Logic redacted for project example
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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
            //Logic redacted for project example
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Logic redacted for project example
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            //Logic redacted for project example
        }

        private void toolStripMenuItemShowContentHeaders_Click(object sender, EventArgs e)
        {
            _RequestEngine.ToggleShowContentHeaders();
        }
    };
}
