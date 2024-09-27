namespace remember_helper
{

    using System;
    using System.IO;
    using System.Windows.Forms;
    using NPOI.SS.UserModel;
    using NPOI.XSSF.UserModel; // 对于 .xlsx 格式
    using NPOI.HSSF.UserModel; // 对于 .xls 格式


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ISheet sheet;
        int currentRowNumber = -1; // 存储当前选中行的行号，初始值为-1表示没有选中行
        string filePath;

        private void Form1_Load(object sender, EventArgs e)
        {
            // 创建并配置OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls"; // 过滤选项，只显示Excel文件
            openFileDialog.Title = "请选择一个Excel文件"; // 对话框标题

            // 显示文件选择对话框
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName; // 获取选中的文件路径

                // 读取Excel文件
                IWorkbook workbook;
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    // 根据文件扩展名选择读取方式
                    if (filePath.EndsWith(".xls"))
                    {
                        workbook = new HSSFWorkbook(fileStream); // 对于 .xls 格式
                    }
                    else
                    {
                        workbook = new XSSFWorkbook(fileStream); // 对于 .xlsx 格式
                    }

                    // 获取第一个工作表
                    sheet = workbook.GetSheetAt(0);

                    // 读取第一列数据
                    IRow row;
                    string column1Data = "";
                    for (int i = 1; i <= sheet.LastRowNum; i++) // 从1开始，因为0是标题行
                    {
                        row = sheet.GetRow(i);
                        if (row != null)
                        {
                            ICell cell = row.GetCell(0); // 第一列
                            if (cell != null)
                            {
                                column1Data += cell.ToString() + Environment.NewLine;
                            }
                        }
                    }

                    // 读取第二列数据
                    string column2Data = "";
                    for (int i = 1; i <= sheet.LastRowNum; i++)
                    {
                        row = sheet.GetRow(i);
                        if (row != null)
                        {
                            ICell cell = row.GetCell(1); // 第二列
                            if (cell != null)
                            {
                                column2Data += cell.ToString() + Environment.NewLine;
                            }
                        }
                    }

                    // 现在你有了两列数据，可以进行后续操作
                    //MessageBox.Show("Column 1: \n" + column1Data);
                    //MessageBox.Show("Column 2: \n" + column2Data);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 获取除标题外的所有行号
            List<int> rows = new List<int>();
            for (int i = 1; i <= sheet.LastRowNum; i++)
            {
                rows.Add(i);
            }

            // 创建Random对象
            Random random = new Random();
            int selectedRowNumber = rows[random.Next(rows.Count)]; // 随机选择一行

            // 获取选中行
            IRow selectedRow = sheet.GetRow(selectedRowNumber);

            // 获取第一列的单元格
            ICell cell = selectedRow.GetCell(0);
            if (cell != null)
            {
                // 将单元格内容设置为Label1的文本
                label1.Text = cell.ToString();
            }
        }
        //1会2不会
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
                MessageBox.Show("没有找到不会的。");
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

                // 保存工作簿
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    sheet.Workbook.Write(fileStream);
                }

                // 重复button2的效果
                button2_Click(sender, e);
            }
            else
            {
                MessageBox.Show("没有选中不会的。");
            }
        }
    }
}
