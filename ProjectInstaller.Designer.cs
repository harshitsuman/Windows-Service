namespace WindowsService9
{
	partial class ProjectInstaller
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

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.serviceProcessInstaller9 = new System.ServiceProcess.ServiceProcessInstaller();
			this.serviceInstaller9 = new System.ServiceProcess.ServiceInstaller();
			// 
			// serviceProcessInstaller9
			// 
			this.serviceProcessInstaller9.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
			this.serviceProcessInstaller9.Password = null;
			this.serviceProcessInstaller9.Username = null;
			// 
			// serviceInstaller9
			// 
			this.serviceInstaller9.Description = "My 9th service Demo";
			this.serviceInstaller9.DisplayName = "My9thservice";
			this.serviceInstaller9.ServiceName = "Service9";
			// 
			// ProjectInstaller
			// 
			this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller9,
            this.serviceInstaller9});

		}

		#endregion

		private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller9;
		private System.ServiceProcess.ServiceInstaller serviceInstaller9;
	}
}