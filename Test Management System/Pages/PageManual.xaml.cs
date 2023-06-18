using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using System.Windows.Markup;
using System.Reflection;

namespace Test_Management_System.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageManual.xaml
    /// </summary>
    public partial class PageManual : Page
    {
        public PageManual()
        {
            InitializeComponent();
            /*
                        string fileContent = Properties.Resources.check;
                        CLDocs.Document.Blocks.Clear();
                        CLDocs.Document.Blocks.Add(new Paragraph(new Run(fileContent)));*/
            string rtfText;

            using (Stream stream = Application.GetResourceStream(new Uri("pack://application:,,,/Test_Management_System;component/Resources/check.rtf")).Stream)
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    rtfText = reader.ReadToEnd();
                }
            }

            TextRange textRange = new TextRange(CLDocs.Document.ContentStart, CLDocs.Document.ContentEnd);

            using (MemoryStream ms = new MemoryStream(Encoding.Default.GetBytes(rtfText)))
            {
                textRange.Load(ms, DataFormats.Rtf);
            }


/*
            string rtfText;

            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Test_Management_System.check.rtf"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    rtfText = reader.ReadToEnd();
                }
            }

            TextRange textRange = new TextRange(CLDocs.Document.ContentStart, CLDocs.Document.ContentEnd);

            using (MemoryStream ms = new MemoryStream(Encoding.Default.GetBytes(rtfText)))
            {
                textRange.Load(ms, DataFormats.Rtf);
            }*/
        }

        //private void OpenFile()
        //{

        //    string file = Properties.Resources.checklist;
        //    File.ReadAllText(file);
        //}

    }
}
