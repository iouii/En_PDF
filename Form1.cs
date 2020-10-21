using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Security;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Pdf
{
    public partial class Form1 : Form
    {

       
        public Form1()
        {
            InitializeComponent();
        }
        string path ;
        string pass,passAdmin;
        int af = 0;
        

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "pdf",
                Filter = "pdf files (*.pdf)|*.pdf",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }  
        }

        public void button1_Click_1(object sender, EventArgs e)
        {

             path = textBox1.Text;
             pass = textBox2.Text;
             passAdmin = textBox3.Text;

            if (path != "" && pass != "")
            {


                if (checkBox9.Checked == true)
                {


                    water(path);

                    if (af == 2)
                    {
                        
                        MessageBox.Show("Plaese Input PDF v.14 ");

                        textBox1.Text = "";
                        textBox2.Text = "";
                        checkBox9.Checked = false;
                        
                    }else{

                        Getpdf(pass, path, passAdmin);
                    }
 
                    
                }

                else
                {

                    Getpdfnone(pass, path, passAdmin);

                }


            }
            else
            {

                MessageBox.Show("Plase Input File or Password");
                textBox1.Text = "";
                textBox2.Text = "";

            }
            

        }

        public void Getpdf(string pass, string path, string passAdmin)
        {



            try
            {
                // Get a fresh copy of the sample PDF file
                //string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                //string filenameDest = "OriginalFile.pdf";

                //File.Copy(Path.Combine(path),
                //Path.Combine(desktopPath, filenameDest), true);

                // Open an existing document. Providing an unrequired password is ignored.

                PdfDocument document = PdfReader.Open(path, "some text");

                PdfSecuritySettings securitySettings = document.SecuritySettings;

                // Setting one of the passwords automatically sets the security level to 
                // PdfDocumentSecurityLevel.Encrypted128Bit.
                securitySettings.UserPassword = pass;
                securitySettings.OwnerPassword = passAdmin;



                // Don't use 40 bit encryption unless needed for compatibility
                //securitySettings.DocumentSecurityLevel = PdfDocumentSecurityLevel.Encrypted40Bit;

                // Restrict some rights.
                if (checkBox1.Checked == true)
                {

                    securitySettings.PermitAccessibilityExtractContent = true;
                }
                else
                {

                    securitySettings.PermitAccessibilityExtractContent = false;
                }

                if (checkBox2.Checked == true)
                {

                    securitySettings.PermitAnnotations = true;
                }
                else
                {

                    securitySettings.PermitAnnotations = false;
                }

                if (checkBox3.Checked == true)
                {

                    securitySettings.PermitAssembleDocument = true;
                }
                else
                {

                    securitySettings.PermitAssembleDocument = false;
                }

                if (checkBox4.Checked == true)
                {

                    securitySettings.PermitExtractContent = true;
                }
                else
                {

                    securitySettings.PermitExtractContent = false;
                }
                if (checkBox5.Checked == true)
                {

                    securitySettings.PermitFormsFill = true;
                }
                else
                {

                    securitySettings.PermitFormsFill = false;
                }

                if (checkBox6.Checked == true)
                {

                    securitySettings.PermitFullQualityPrint = true;
                }
                else
                {

                    securitySettings.PermitFullQualityPrint = false;
                }

                if (checkBox7.Checked == true)
                {

                    securitySettings.PermitModifyDocument = true;
                }
                else
                {

                    securitySettings.PermitModifyDocument = false;
                }
                if (checkBox8.Checked == true)
                {

                    securitySettings.PermitPrint = true;
                }
                else
                {

                    securitySettings.PermitPrint = false;
                }





                // Save the document...
                document.Save(path);
                // ...and start a viewer.
                MessageBox.Show("Encrpted PDF Success");

                textBox1.Text = "";
                textBox2.Text = "";
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                Process.Start(path);





            }
            catch (Exception e)
            {

                throw new Exception(e.Message, e.InnerException);

            }


        }



        public void Getpdfnone(string pass, string path, string passAdmin)
        {

            string namef = Path.GetFileName(path);


            try
            {
                // Get a fresh copy of the sample PDF file
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filenameDest = "(n)" + namef;

                File.Copy(Path.Combine(path),
                Path.Combine(desktopPath, filenameDest), true);

                // Open an existing document. Providing an unrequired password is ignored.

                PdfDocument document = PdfReader.Open(path, "some text");

                PdfSecuritySettings securitySettings = document.SecuritySettings;

                // Setting one of the passwords automatically sets the security level to 
                // PdfDocumentSecurityLevel.Encrypted128Bit.
                securitySettings.UserPassword = pass;
                securitySettings.OwnerPassword = "OCTADMIN";




                // Don't use 40 bit encryption unless needed for compatibility
                //securitySettings.DocumentSecurityLevel = PdfDocumentSecurityLevel.Encrypted40Bit;

                // Restrict some rights.
                if (checkBox1.Checked == true)
                {

                    securitySettings.PermitAccessibilityExtractContent = true;
                }
                else
                {

                    securitySettings.PermitAccessibilityExtractContent = false;
                }

                if (checkBox2.Checked == true)
                {

                    securitySettings.PermitAnnotations = true;
                }
                else
                {

                    securitySettings.PermitAnnotations = false;
                }

                if (checkBox3.Checked == true)
                {

                    securitySettings.PermitAssembleDocument = true;
                }
                else
                {

                    securitySettings.PermitAssembleDocument = false;
                }

                if (checkBox4.Checked == true)
                {

                    securitySettings.PermitExtractContent = true;
                }
                else
                {

                    securitySettings.PermitExtractContent = false;
                }
                if (checkBox5.Checked == true)
                {

                    securitySettings.PermitFormsFill = true;
                }
                else
                {

                    securitySettings.PermitFormsFill = false;
                }

                if (checkBox6.Checked == true)
                {

                    securitySettings.PermitFullQualityPrint = true;
                }
                else
                {

                    securitySettings.PermitFullQualityPrint = false;
                }

                if (checkBox7.Checked == true)
                {

                    securitySettings.PermitModifyDocument = true;
                }
                else
                {

                    securitySettings.PermitModifyDocument = false;
                }
                if (checkBox8.Checked == true)
                {

                    securitySettings.PermitPrint = true;
                }
                else
                {

                    securitySettings.PermitPrint = false;
                }





                // Save the document...
                document.Save(path);
                // ...and start a viewer.
                MessageBox.Show("Encrpted PDF Success");

                textBox1.Text = "";
                textBox2.Text = "";
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                Process.Start(path);





            }
            catch (Exception e)
            {

                throw new Exception(e.Message, e.InnerException);

            }


        }

       
        public void water(string pathz)
        {

            string namef = Path.GetFileName(pathz);
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filenameDest = "(N)" + namef;

            File.Copy(Path.Combine(pathz),
            Path.Combine(desktopPath, filenameDest), true);

           
            PdfDocument documentz = PdfReader.Open(pathz, "some text");


            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(pathz);

            string doc = loadedDocument.FileStructure.Version.ToString();

            string a = doc[7].ToString();
            string b = doc[9].ToString();
            string c = a+"."+b;

            double d =  Double.Parse(c);
            
            

            if (d >= 1.4)
            {

            //Add watermark to first page

            var pr = documentz.PageCount;

            for (var i = 0; i < pr; i++)
            {

                string watermark = "OguraClutch(Thailand)";
                var page = documentz.Pages[i];
                //The new content will be rendered above the existing graphic.
                var gfx = XGraphics.FromPdfPage(page, XGraphicsPdfPageOptions.Append);

                // Set text font, location and rotation
                var textFont = new XFont("Times New Roman", 60f, XFontStyle.BoldItalic);
                var location = new XPoint(-150, 350);

                int rotation = -45;

                // Create a red brush with transparency
                var textColor = XColor.FromArgb(128, 255, 0, 0);

                var brush = new XSolidBrush(textColor);

                // Set a text format.
                var format = new XStringFormat();
                format.Alignment = XStringAlignment.Near;
                format.LineAlignment = XLineAlignment.Near;

                // Get the size (in points) of the text.
                var size = gfx.MeasureString(watermark, textFont);

                //Change text orientation from left-bottom to top-right          
                gfx.TranslateTransform((location.X + size.Width) / 2, (location.Y + size.Height) / 2);
                gfx.RotateTransform(rotation);
                gfx.TranslateTransform(-(location.X + size.Width) / 2, -(location.Y + size.Height) / 2);

                //Draw watermark to page
                gfx.DrawString(watermark, textFont, brush, location, format);


                // PDF 1.4+ support transparency.
                if (documentz.Version < 14)
                    documentz.Version = 14;

                documentz.Save(pathz);


            }

            af = 1;

            }
            else
            {

                
               

                af = 2;

            }

        }

        public void watero(string pathz)
        {

            string namef = Path.GetFileName(pathz);
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filenameDest = "(N)" + namef;

            File.Copy(Path.Combine(pathz),
            Path.Combine(desktopPath, filenameDest), true);

            PdfDocument documentz = PdfReader.Open(pathz, "some text");

            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(pathz);

            string doc = loadedDocument.FileStructure.Version.ToString();

            string a = doc[7].ToString();
            string b = doc[9].ToString();
            string c = a + "." + b;

            double d = Double.Parse(c);

            if (d >= 1.4)
            {


                //Add watermark to first page

                var pr = documentz.PageCount;

                for (var i = 0; i < pr; i++)
                {

                    string watermark = "OguraClutch(Thailand)";
                    var page = documentz.Pages[i];
                    //The new content will be rendered above the existing graphic.
                    var gfx = XGraphics.FromPdfPage(page, XGraphicsPdfPageOptions.Append);

                    // Set text font, location and rotation
                    var textFont = new XFont("Times New Roman", 60f, XFontStyle.Bold);
                    var location = new XPoint(-150, 350);

                    int rotation = -45;

                    // Create a red brush with transparency
                    var textColor = XColor.FromArgb(128, 255, 0, 0);

                    var brush = new XSolidBrush(textColor);

                    // Set a text format.
                    var format = new XStringFormat();
                    format.Alignment = XStringAlignment.Near;
                    format.LineAlignment = XLineAlignment.Near;

                    // Get the size (in points) of the text.
                    var size = gfx.MeasureString(watermark, textFont);

                    //Change text orientation from left-bottom to top-right          
                    gfx.TranslateTransform((location.X + size.Width) / 2, (location.Y + size.Height) / 2);
                    gfx.RotateTransform(rotation);
                    gfx.TranslateTransform(-(location.X + size.Width) / 2, -(location.Y + size.Height) / 2);

                    //Draw watermark to page
                    gfx.DrawString(watermark, textFont, brush, location, format);


                    // PDF 1.4+ support transparency.
                    if (documentz.Version < 14)
                        documentz.Version = 14;

                    documentz.Save(pathz);




                }


                MessageBox.Show("Encrpted PDF Success");

                textBox1.Text = "";
                textBox2.Text = "";
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
               
                af = 1;

            }
            else
            {




                af = 2;

            }

        }
        public void button2_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;

            if (checkBox9.Checked == true)
            {
                if (path != "")
                {

                    watero(path);

                    if(af == 1){
                        MessageBox.Show("Suc ");

                    }else{
                        MessageBox.Show("Plaese Input PDF version 14++ ");
                        checkBox9.Checked = false;
                        textBox1.Text = "";
                    }
                }
                else
                {

                    MessageBox.Show("Plaese Input PDF ");
                }
                
            }
            else
            {

                MessageBox.Show("Plaese checked 'Water Mark OguraClutch(Thailand) PDF 1.4+ support'  ");
            }
        }

 

    }
}
