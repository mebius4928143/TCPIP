using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPServer;

namespace SV
{
    public partial class Form1 : Form
    {
		///// <summary>
		///// ウィンドウに表示するタイトル
		///// </summary>
		//public ReactivePropertySlim<string> Title { get; } = new ReactivePropertySlim<string>("TCP Server");

		///// <summary>
		///// Disposeが必要な処理をまとめてやる
		///// </summary>
		//private CompositeDisposable Disposable { get; } = new CompositeDisposable();

		///// <summary>
		///// MainWindowのCloseイベント
		///// </summary>
		//public ReactiveCommand ClosedCommand { get; } = new ReactiveCommand();

		///// <summary>
		///// TCP Server オープン
		///// </summary>
		//public ReactiveCommand OpenCommand { get; } = new ReactiveCommand();

		///// <summary>
		///// TCP Server クローズ
		///// </summary>
		//public ReactiveCommand CloseCommand { get; } = new ReactiveCommand();

		/// <summary>
		/// 送受信するデータ
		/// </summary>
		//public ReactivePropertySlim<string> TcpData { get; } = new ReactivePropertySlim<string>(string.Empty);
		public List<string> TcpData { get; } = new List<string>(new string[] { string.Empty });

		/// <summary>
		/// これがTCPクライアントと接続するTCPサーバ
		/// </summary>
		private readonly Server server;

		public Form1()
        {
            InitializeComponent();
            server = new Server(false, false, SendData);
        }

		/// <summary>
		/// TCP通信を接続する
		/// </summary>
		private void tcpOpne()
		{
			server.Open("127.0.0.1", 8000, 2, 1024);
		}

		/// <summary>
		/// TCP通信を切断する
		/// </summary>
		private void tcpClose()
		{
			server.Close();
		}

		internal string SendData(string getString)
		{
			//TcpData. = getString;
			return getString;
		}

		/// <summary>
		/// アプリが閉じられる時
		/// </summary>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
			server.Close();
		}

        private void button1_Click(object sender, EventArgs e)
        {
			tcpOpne();
        }

        private void button2_Click(object sender, EventArgs e)
        {
			this.tcpClose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
			this.Close();
        }
    }
}
