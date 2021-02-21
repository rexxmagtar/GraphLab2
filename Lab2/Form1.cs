using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using FreeImageAPI;
using FreeImageAPI.Metadata;
using ImageMagick;
using Directory = System.IO.Directory;

namespace Lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void submitGetInfoButton_Click(object sender, EventArgs e)
        {
            var filePickResult = openFileDialog1.ShowDialog();

            if (filePickResult != DialogResult.OK)
            {
                return;
            }

            try
            {
                AddNewImageInfo(openFileDialog1.FileName, true);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void fileInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void folderSelectButton_Click(object sender, EventArgs e)
        {
            var folderResult = folderBrowserDialog1.ShowDialog();

            if (folderResult != DialogResult.OK)
            {
                return;
            }

            dataGridView1.Rows.Clear();

            var files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);

            for (int i = 0; i < files.Length; i++)
            {
                try
                {
                    AddNewImageInfo(files[i]);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;

                }
            }

        }

        private void AddNewImageInfo(string imagePath, bool clearTable = false)
        {
            string fileName = new FileInfo(imagePath).Name;



            string imgType = imagePath.Substring(imagePath.LastIndexOf('.')+1, imagePath.Length - 1 - imagePath.LastIndexOf('.'));

            if (imgType.Equals("pcx",StringComparison.OrdinalIgnoreCase))
            {


                FREE_IMAGE_FORMAT formatR = FREE_IMAGE_FORMAT.FIF_UNKNOWN;

                // Try loading the file
                FIBITMAP dib = FreeImage.LoadEx(imagePath, ref formatR);


                uint width = FreeImage.GetWidth(dib);

                uint height = FreeImage.GetHeight(dib);


                float horizontalResolution = FreeImage.GetResolutionX(dib);

                float verticalResolution = FreeImage.GetResolutionY(dib);

                //var format = img.PixelFormat;

                uint colorDepth = FreeImage.GetBPP(dib);

                var compression = "";

                int compressionId = 1;

                try
                {
                    //compressionId = BitConverter.ToInt16(img.GetPropertyItem(0x0103).Value, 0);
                }
                catch (Exception)
                {

                }

                //switch (compressionId)
                //{
                //    case 1:
                //        compression = "No compression";
                //        break;
                //    case 2:
                //        compression = "CCITT Huffman";
                //        break;
                //    case 3:
                //        compression = "CCITT Group 3";
                //        break;
                //    case 4:
                //        compression = "CCITT Group 4";
                //        break;
                //    case 5:
                //        compression = "LZW";
                //        break;
                //    default:
                //        compression = "Unknown compression";
                //        break;

                //}

                compression = GetCompressionName(dib);

                if (clearTable)
                {
                    dataGridView1.Rows.Clear();
                }

                int newIndex = dataGridView1.Rows.Add();

                var gridRow = (DataGridViewRow)dataGridView1.Rows[newIndex];

                gridRow.Cells["NameColumn"].Value = fileName;
                gridRow.Cells["Size"].Value = width + "x" + height;
                gridRow.Cells["Resolution"].Value = horizontalResolution + "x" + verticalResolution;
                gridRow.Cells["ColorDepth"].Value = colorDepth;
                gridRow.Cells["CompressionColumn"].Value = compression;

                FreeImage.UnloadEx(ref dib);

                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();

            }
            else
            {

                Image img = Image.FromFile(imagePath);


                int width = img.Width;

                int height = img.Height;


                float horizontalResolution = img.HorizontalResolution;

                float verticalResolution = img.VerticalResolution;

                var format = img.PixelFormat;

                int colorDepth = Image.GetPixelFormatSize(format);

                var compression = "";

                int compressionId = 1;

                try
                {
                    compressionId = BitConverter.ToInt16(img.GetPropertyItem(0x0103).Value, 0);
                }
                catch (Exception)
                {

                }

                switch (compressionId)
                {
                    case 1:
                        compression = "No compression";
                        break;
                    case 2:
                        compression = "CCITT Huffman";
                        break;
                    case 3:
                        compression = "CCITT Group 3";
                        break;
                    case 4:
                        compression = "CCITT Group 4";
                        break;
                    case 5:
                        compression = "LZW";
                        break;
                    default:
                        compression = "Unknown compression id (" + compressionId + ")";
                        break;

                }

                if (clearTable)
                {
                    dataGridView1.Rows.Clear();
                }

                int newIndex = dataGridView1.Rows.Add();

                var gridRow = (DataGridViewRow)dataGridView1.Rows[newIndex];

                gridRow.Cells["NameColumn"].Value = fileName;
                gridRow.Cells["Size"].Value = width + "x" + height;
                gridRow.Cells["Resolution"].Value = horizontalResolution + "x" + verticalResolution;
                gridRow.Cells["ColorDepth"].Value = colorDepth;
                gridRow.Cells["CompressionColumn"].Value = compression;

                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
            }

        }


        public string GetCompressionName(FIBITMAP dib)
        {
            long _compression;

            if (dib.IsNull)
                throw new Exception("dib is empty - image haven't been loaded!");

            //Searching tag in metadata.
            ImageMetadata iMetadata = new ImageMetadata(dib);

            foreach (MetadataModel metadataModel in iMetadata)
            {
                if (metadataModel.ToString() == "FIMD_EXIF_MAIN")
                {
                    try
                    {
                        long.TryParse((metadataModel.GetTag("Compression")?.Value as ushort[])?[0].ToString(), out _compression);
                    }
                    catch (Exception ex)
                    {
                        return "Unknown";
                    }


                    if (CompressType.ContainsKey(_compression))
                    {
                        string _compressionName;
                        CompressType.TryGetValue(_compression, out _compressionName);

                        if (_compressionName != null)
                        {
                            return _compressionName;
                        }
                    }
                }
            }

            return "Unknown";
        }

        Dictionary<long, string> CompressType = new Dictionary<long, string>()
        {
            {1, "Uncompressed"},
            {2, "CCITT modified Huffman RLE"},
            {32773, "PackBits"},
            {3, "CCITT3"},
            {4, "CCITT4"},
            {5, "LZW"},
            {6, "JPEG_old"},
            {7, "JPEG_new"},
            {32946, "DeflatePKZIP"},
            {8, "DeflateAdobe"},
            {9, "JBIG_85"},
            {10, "JBIG_43"},
            {11, "JPEG"},
            {12, "JPEG"},
            {32766, "RLE_NeXT"},
            {32809, "RLE_ThunderScan"},
            {32895, "RasterPadding"},
            {32896, "RLE_LW"},
            {32897, "RLE_HC"},
            {32947, "RLE_BL"},
            {34661, "JBIG"},
            {34713, "Nikon_NEF"},
            {34712, "JPEG2000"}
        };
    }
}