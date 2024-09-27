namespace remember_helper
{

    using System;
    using System.IO;
    using System.Windows.Forms;
    using NPOI.SS.UserModel;
    using NPOI.XSSF.UserModel; // ���� .xlsx ��ʽ
    using NPOI.HSSF.UserModel; // ���� .xls ��ʽ


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ISheet sheet;
        int currentRowNumber = -1; // �洢��ǰѡ���е��кţ���ʼֵΪ-1��ʾû��ѡ����
        string filePath;

        private void Form1_Load(object sender, EventArgs e)
        {
            // ����������OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls"; // ����ѡ�ֻ��ʾExcel�ļ�
            openFileDialog.Title = "��ѡ��һ��Excel�ļ�"; // �Ի������

            // ��ʾ�ļ�ѡ��Ի���
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName; // ��ȡѡ�е��ļ�·��

                // ��ȡExcel�ļ�
                IWorkbook workbook;
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    // �����ļ���չ��ѡ���ȡ��ʽ
                    if (filePath.EndsWith(".xls"))
                    {
                        workbook = new HSSFWorkbook(fileStream); // ���� .xls ��ʽ
                    }
                    else
                    {
                        workbook = new XSSFWorkbook(fileStream); // ���� .xlsx ��ʽ
                    }

                    // ��ȡ��һ��������
                    sheet = workbook.GetSheetAt(0);

                    // ��ȡ��һ������
                    IRow row;
                    string column1Data = "";
                    for (int i = 1; i <= sheet.LastRowNum; i++) // ��1��ʼ����Ϊ0�Ǳ�����
                    {
                        row = sheet.GetRow(i);
                        if (row != null)
                        {
                            ICell cell = row.GetCell(0); // ��һ��
                            if (cell != null)
                            {
                                column1Data += cell.ToString() + Environment.NewLine;
                            }
                        }
                    }

                    // ��ȡ�ڶ�������
                    string column2Data = "";
                    for (int i = 1; i <= sheet.LastRowNum; i++)
                    {
                        row = sheet.GetRow(i);
                        if (row != null)
                        {
                            ICell cell = row.GetCell(1); // �ڶ���
                            if (cell != null)
                            {
                                column2Data += cell.ToString() + Environment.NewLine;
                            }
                        }
                    }

                    // �����������������ݣ����Խ��к�������
                    //MessageBox.Show("Column 1: \n" + column1Data);
                    //MessageBox.Show("Column 2: \n" + column2Data);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ��ȡ��������������к�
            List<int> rows = new List<int>();
            for (int i = 1; i <= sheet.LastRowNum; i++)
            {
                rows.Add(i);
            }

            // ����Random����
            Random random = new Random();
            int selectedRowNumber = rows[random.Next(rows.Count)]; // ���ѡ��һ��

            // ��ȡѡ����
            IRow selectedRow = sheet.GetRow(selectedRowNumber);

            // ��ȡ��һ�еĵ�Ԫ��
            ICell cell = selectedRow.GetCell(0);
            if (cell != null)
            {
                // ����Ԫ����������ΪLabel1���ı�
                label1.Text = cell.ToString();
            }
        }
        //1��2����
        private void button2_Click(object sender, EventArgs e)
        {
            List<int> rowsWithSecondColumnAsTwo = new List<int>();
            for (int i = 1; i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                if (row != null)
                {
                    ICell cell = row.GetCell(1);
                    if (cell != null && cell.NumericCellValue == 2)
                    {
                        rowsWithSecondColumnAsTwo.Add(i);
                    }
                }
            }

            if (rowsWithSecondColumnAsTwo.Count > 0)
            {
                Random random = new Random();
                currentRowNumber = rowsWithSecondColumnAsTwo[random.Next(rowsWithSecondColumnAsTwo.Count)];
                IRow selectedRow = sheet.GetRow(currentRowNumber);
                ICell cell = selectedRow.GetCell(0);
                if (cell != null)
                {
                    label1.Text = cell.ToString();
                }
            }
            else
            {
                MessageBox.Show("û���ҵ�����ġ�");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (currentRowNumber != -1)
            {
                IRow row = sheet.GetRow(currentRowNumber);
                if (row != null)
                {
                    ICell cell = row.GetCell(1);
                    if (cell != null)
                    {
                        cell.SetCellValue(1);
                    }
                }

                // ���湤����
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    sheet.Workbook.Write(fileStream);
                }

                // �ظ�button2��Ч��
                button2_Click(sender, e);
            }
            else
            {
                MessageBox.Show("û��ѡ�в���ġ�");
            }
        }
    }
}
