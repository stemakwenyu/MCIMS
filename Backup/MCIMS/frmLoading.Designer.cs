namespace MCIMS
{
    partial class frmLoading
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox56 = new System.Windows.Forms.GroupBox();
            this.gboxSearch = new System.Windows.Forms.GroupBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnDetails = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cboAcYrSearch = new System.Windows.Forms.ComboBox();
            this.cboSemesterSearch = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtSearchValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboSearchCriteria = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.LoadingCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CourseCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Venue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LectureTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Semester = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcademicYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaffNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaffName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnPostLoading = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboLoadingCode = new System.Windows.Forms.ComboBox();
            this.cboAcYr = new System.Windows.Forms.ComboBox();
            this.cboStaffName = new System.Windows.Forms.ComboBox();
            this.cboSemester = new System.Windows.Forms.ComboBox();
            this.lblStaffNo = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboCourse = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVenue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLoadingCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblTime2 = new System.Windows.Forms.Label();
            this.groupBox56.SuspendLayout();
            this.gboxSearch.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox56
            // 
            this.groupBox56.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox56.Controls.Add(this.gboxSearch);
            this.groupBox56.Controls.Add(this.groupBox1);
            this.groupBox56.Location = new System.Drawing.Point(12, 20);
            this.groupBox56.Name = "groupBox56";
            this.groupBox56.Size = new System.Drawing.Size(840, 473);
            this.groupBox56.TabIndex = 6;
            this.groupBox56.TabStop = false;
            // 
            // gboxSearch
            // 
            this.gboxSearch.Controls.Add(this.lblTime);
            this.gboxSearch.Controls.Add(this.btnDetails);
            this.gboxSearch.Controls.Add(this.btnRefresh);
            this.gboxSearch.Controls.Add(this.btnPrint);
            this.gboxSearch.Controls.Add(this.groupBox5);
            this.gboxSearch.Controls.Add(this.dataGridView1);
            this.gboxSearch.Location = new System.Drawing.Point(51, 10);
            this.gboxSearch.Name = "gboxSearch";
            this.gboxSearch.Size = new System.Drawing.Size(744, 410);
            this.gboxSearch.TabIndex = 7;
            this.gboxSearch.TabStop = false;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.DarkGray;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.Blue;
            this.lblTime.Location = new System.Drawing.Point(243, 369);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 13);
            this.lblTime.TabIndex = 11;
            this.lblTime.Click += new System.EventHandler(this.lblTime_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.Location = new System.Drawing.Point(507, 360);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(86, 27);
            this.btnDetails.TabIndex = 10;
            this.btnDetails.Text = "D&etails";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(609, 357);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(88, 30);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(21, 360);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(111, 30);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.LightGray;
            this.groupBox5.Controls.Add(this.cboAcYrSearch);
            this.groupBox5.Controls.Add(this.cboSemesterSearch);
            this.groupBox5.Controls.Add(this.label22);
            this.groupBox5.Controls.Add(this.btnClear);
            this.groupBox5.Controls.Add(this.btnFind);
            this.groupBox5.Controls.Add(this.txtSearchValue);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.cboSearchCriteria);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Location = new System.Drawing.Point(22, 13);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(689, 104);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            // 
            // cboAcYrSearch
            // 
            this.cboAcYrSearch.FormattingEnabled = true;
            this.cboAcYrSearch.Items.AddRange(new object[] {
            "2012/2013",
            "2013/2014",
            "2014/2015",
            "2015/2016",
            "2016/2017",
            "2017/2018",
            "2018/2019",
            "2019/2020"});
            this.cboAcYrSearch.Location = new System.Drawing.Point(298, 12);
            this.cboAcYrSearch.Name = "cboAcYrSearch";
            this.cboAcYrSearch.Size = new System.Drawing.Size(104, 21);
            this.cboAcYrSearch.TabIndex = 16;
            // 
            // cboSemesterSearch
            // 
            this.cboSemesterSearch.FormattingEnabled = true;
            this.cboSemesterSearch.Items.AddRange(new object[] {
            "I",
            "II",
            "III"});
            this.cboSemesterSearch.Location = new System.Drawing.Point(161, 13);
            this.cboSemesterSearch.Name = "cboSemesterSearch";
            this.cboSemesterSearch.Size = new System.Drawing.Size(112, 21);
            this.cboSemesterSearch.TabIndex = 15;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(12, 13);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(102, 16);
            this.label22.TabIndex = 14;
            this.label22.Text = "Semester/Year:";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(460, 47);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(123, 23);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(460, 13);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(123, 23);
            this.btnFind.TabIndex = 12;
            this.btnFind.Text = "&Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtSearchValue
            // 
            this.txtSearchValue.Location = new System.Drawing.Point(161, 77);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.Size = new System.Drawing.Size(241, 20);
            this.txtSearchValue.TabIndex = 11;
            this.txtSearchValue.Text = "All";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Search Value:";
            // 
            // cboSearchCriteria
            // 
            this.cboSearchCriteria.FormattingEnabled = true;
            this.cboSearchCriteria.Items.AddRange(new object[] {
            "All",
            "Course Code",
            "Program Code"});
            this.cboSearchCriteria.Location = new System.Drawing.Point(161, 44);
            this.cboSearchCriteria.Name = "cboSearchCriteria";
            this.cboSearchCriteria.Size = new System.Drawing.Size(241, 21);
            this.cboSearchCriteria.TabIndex = 9;
            this.cboSearchCriteria.Text = "All";
            this.cboSearchCriteria.SelectedIndexChanged += new System.EventHandler(this.cboSearchCriteria_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Search Criteria:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LoadingCode,
            this.CourseCode,
            this.Venue,
            this.LectureTime,
            this.Semester,
            this.AcademicYear,
            this.StaffNo,
            this.StaffName});
            this.dataGridView1.Location = new System.Drawing.Point(19, 124);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(689, 229);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // LoadingCode
            // 
            this.LoadingCode.HeaderText = "Loading Code";
            this.LoadingCode.Name = "LoadingCode";
            this.LoadingCode.Width = 98;
            // 
            // CourseCode
            // 
            this.CourseCode.HeaderText = "Course";
            this.CourseCode.Name = "CourseCode";
            this.CourseCode.Width = 65;
            // 
            // Venue
            // 
            this.Venue.HeaderText = "Venue";
            this.Venue.Name = "Venue";
            this.Venue.Width = 63;
            // 
            // LectureTime
            // 
            this.LectureTime.HeaderText = "Lecture Time";
            this.LectureTime.Name = "LectureTime";
            this.LectureTime.Width = 94;
            // 
            // Semester
            // 
            this.Semester.HeaderText = "Semester";
            this.Semester.Name = "Semester";
            this.Semester.Width = 76;
            // 
            // AcademicYear
            // 
            this.AcademicYear.HeaderText = "Academic Year";
            this.AcademicYear.Name = "AcademicYear";
            this.AcademicYear.Width = 104;
            // 
            // StaffNo
            // 
            this.StaffNo.HeaderText = "Staff No";
            this.StaffNo.Name = "StaffNo";
            this.StaffNo.Width = 71;
            // 
            // StaffName
            // 
            this.StaffName.HeaderText = "Staff Name";
            this.StaffName.Name = "StaffName";
            this.StaffName.Width = 85;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(79, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(689, 284);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.LightGray;
            this.groupBox3.Controls.Add(this.lblTime2);
            this.groupBox3.Controls.Add(this.btnNew);
            this.groupBox3.Controls.Add(this.btnEdit);
            this.groupBox3.Controls.Add(this.btnPostLoading);
            this.groupBox3.Controls.Add(this.btnSearch);
            this.groupBox3.Controls.Add(this.btnDelete);
            this.groupBox3.Controls.Add(this.btnQuit);
            this.groupBox3.Controls.Add(this.btnReset);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Location = new System.Drawing.Point(44, 191);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(606, 77);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(285, 12);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(67, 29);
            this.btnNew.TabIndex = 13;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(358, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(55, 29);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnPostLoading
            // 
            this.btnPostLoading.Location = new System.Drawing.Point(163, 12);
            this.btnPostLoading.Name = "btnPostLoading";
            this.btnPostLoading.Size = new System.Drawing.Size(80, 29);
            this.btnPostLoading.TabIndex = 6;
            this.btnPostLoading.Text = "Post Loading";
            this.btnPostLoading.UseVisualStyleBackColor = true;
            this.btnPostLoading.Click += new System.EventHandler(this.btnPostLoading_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(419, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(70, 29);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Searc&h";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(495, 14);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(52, 27);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(553, 14);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(41, 27);
            this.btnQuit.TabIndex = 3;
            this.btnQuit.Text = "&Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(91, 14);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(66, 29);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(13, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 29);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboLoadingCode);
            this.groupBox2.Controls.Add(this.cboAcYr);
            this.groupBox2.Controls.Add(this.cboStaffName);
            this.groupBox2.Controls.Add(this.cboSemester);
            this.groupBox2.Controls.Add(this.lblStaffNo);
            this.groupBox2.Controls.Add(this.txtTime);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cboCourse);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtVenue);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtLoadingCode);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(44, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(606, 166);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // cboLoadingCode
            // 
            this.cboLoadingCode.FormattingEnabled = true;
            this.cboLoadingCode.Location = new System.Drawing.Point(137, 24);
            this.cboLoadingCode.Name = "cboLoadingCode";
            this.cboLoadingCode.Size = new System.Drawing.Size(159, 21);
            this.cboLoadingCode.TabIndex = 35;
            this.cboLoadingCode.SelectedIndexChanged += new System.EventHandler(this.cboLoadingCode_SelectedIndexChanged);
            // 
            // cboAcYr
            // 
            this.cboAcYr.FormattingEnabled = true;
            this.cboAcYr.Items.AddRange(new object[] {
            "2012/2013",
            "2013/2014",
            "2014/2015",
            "2015/2016",
            "2016/2017",
            "2017/2018",
            "2018/2019",
            "2019/2020"});
            this.cboAcYr.Location = new System.Drawing.Point(137, 101);
            this.cboAcYr.Name = "cboAcYr";
            this.cboAcYr.Size = new System.Drawing.Size(160, 21);
            this.cboAcYr.TabIndex = 34;
            this.cboAcYr.SelectedIndexChanged += new System.EventHandler(this.cboAcYr_SelectedIndexChanged);
            // 
            // cboStaffName
            // 
            this.cboStaffName.FormattingEnabled = true;
            this.cboStaffName.Location = new System.Drawing.Point(435, 82);
            this.cboStaffName.Name = "cboStaffName";
            this.cboStaffName.Size = new System.Drawing.Size(159, 21);
            this.cboStaffName.TabIndex = 33;
            this.cboStaffName.SelectedIndexChanged += new System.EventHandler(this.cboStaffName_SelectedIndexChanged);
            // 
            // cboSemester
            // 
            this.cboSemester.FormattingEnabled = true;
            this.cboSemester.Items.AddRange(new object[] {
            "I",
            "II",
            "III"});
            this.cboSemester.Location = new System.Drawing.Point(137, 74);
            this.cboSemester.Name = "cboSemester";
            this.cboSemester.Size = new System.Drawing.Size(159, 21);
            this.cboSemester.TabIndex = 31;
            this.cboSemester.SelectedIndexChanged += new System.EventHandler(this.cboSemester_SelectedIndexChanged);
            // 
            // lblStaffNo
            // 
            this.lblStaffNo.AutoSize = true;
            this.lblStaffNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffNo.Location = new System.Drawing.Point(431, 118);
            this.lblStaffNo.Name = "lblStaffNo";
            this.lblStaffNo.Size = new System.Drawing.Size(0, 20);
            this.lblStaffNo.TabIndex = 29;
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(435, 54);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(159, 20);
            this.txtTime.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(305, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 20);
            this.label13.TabIndex = 20;
            this.label13.Text = "Lecturer:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 20);
            this.label8.TabIndex = 10;
            this.label8.Text = "Year:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(305, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Time:";
            // 
            // cboCourse
            // 
            this.cboCourse.FormattingEnabled = true;
            this.cboCourse.Location = new System.Drawing.Point(435, 27);
            this.cboCourse.Name = "cboCourse";
            this.cboCourse.Size = new System.Drawing.Size(159, 21);
            this.cboCourse.TabIndex = 7;
            this.cboCourse.SelectedIndexChanged += new System.EventHandler(this.cboCourse_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(305, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Course:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Semester:";
            // 
            // txtVenue
            // 
            this.txtVenue.Location = new System.Drawing.Point(137, 51);
            this.txtVenue.Name = "txtVenue";
            this.txtVenue.Size = new System.Drawing.Size(159, 20);
            this.txtVenue.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Venue:";
            // 
            // txtLoadingCode
            // 
            this.txtLoadingCode.Enabled = false;
            this.txtLoadingCode.Location = new System.Drawing.Point(137, 25);
            this.txtLoadingCode.Name = "txtLoadingCode";
            this.txtLoadingCode.Size = new System.Drawing.Size(159, 20);
            this.txtLoadingCode.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loading Code:";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblTime2
            // 
            this.lblTime2.AutoSize = true;
            this.lblTime2.BackColor = System.Drawing.Color.DarkGray;
            this.lblTime2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime2.ForeColor = System.Drawing.Color.Blue;
            this.lblTime2.Location = new System.Drawing.Point(20, 57);
            this.lblTime2.Name = "lblTime2";
            this.lblTime2.Size = new System.Drawing.Size(0, 13);
            this.lblTime2.TabIndex = 14;
            // 
            // frmLoading
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(959, 505);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox56);
            this.Name = "frmLoading";
            this.Text = "Loading";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLoading_Load);
            this.groupBox56.ResumeLayout(false);
            this.gboxSearch.ResumeLayout(false);
            this.gboxSearch.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox56;
        private System.Windows.Forms.GroupBox gboxSearch;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cboAcYrSearch;
        private System.Windows.Forms.ComboBox cboSemesterSearch;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtSearchValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboSearchCriteria;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboSemester;
        private System.Windows.Forms.Label lblStaffNo;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboCourse;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVenue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLoadingCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboStaffName;
        private System.Windows.Forms.ComboBox cboAcYr;
        private System.Windows.Forms.Button btnPostLoading;
        private System.Windows.Forms.ComboBox cboLoadingCode;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoadingCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Venue;
        private System.Windows.Forms.DataGridViewTextBoxColumn LectureTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Semester;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcademicYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffName;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblTime2;
    }
}