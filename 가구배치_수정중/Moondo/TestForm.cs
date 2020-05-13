using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moondo
{
    public partial class TestForm : Form
    {
        int allItem = 0;//이 Form에서 사용된 총 아이템 갯수
        Point mousePos;
        Bitmap origin; //임시
        Color curcolor = Color.Blue; //임시

        int tempIndex; //위치 이동을 위한 위치 변경 temp

        PictureBox focusedPictureBox = new PictureBox();

        //가구별 index는 태그를 통해 함.
        PictureBox[] itemImage = new PictureBox[12]; //가구 픽쳐박스 담을 배열
        public static Point[] itemLocation = new Point[12]; //가구 픽쳐박스 위치 담을 배열 

        public TestForm()
        {
            InitializeComponent();
            init();

        }

        private void init()
        {
        }


        private void ItemButton_Click(object sender, EventArgs e) //가구 이름 버튼 눌렀을 때
        {
            int indexNumber = Convert.ToInt32((sender as Button).Tag); //버튼의 Tag를 가져옴
            String itemName = (sender as Button).Text; //버튼의 Text를 가져옴
            Bitmap itemBitmap;

            itemImage[indexNumber] = new PictureBox(); // 픽쳐박스 동적 생성

            switch (itemName)   //프로젝트 내의 사진파일 불러와서 bitmap에 넣기
            {
                case "TV":
                    itemBitmap = new Bitmap(Properties.Resources.TV);
                    break;
                case "서랍장":
                    itemBitmap = new Bitmap(Properties.Resources.서랍장);
                    break;
                case "소파":
                    itemBitmap = new Bitmap(Properties.Resources.소파);
                    break;
                case "옷장":
                    itemBitmap = new Bitmap(Properties.Resources.옷장);
                    break;
                case "이불장":
                    itemBitmap = new Bitmap(Properties.Resources.이불장);
                    break;
                case "장식장":
                    itemBitmap = new Bitmap(Properties.Resources.장식장);
                    break;
                case "창문":
                    itemBitmap = new Bitmap(Properties.Resources.창문);
                    break;
                case "책상":
                    itemBitmap = new Bitmap(Properties.Resources.책상);
                    break;
                case "침대":
                    itemBitmap = new Bitmap(Properties.Resources.침대);
                    break;
                case "컴퓨터":
                    itemBitmap = new Bitmap(Properties.Resources.컴퓨터);
                    break;
                case "피아노":
                    itemBitmap = new Bitmap(Properties.Resources.피아노);
                    break;
                case "화장대":
                    itemBitmap = new Bitmap(Properties.Resources.화장대);
                    break;
                default:
                    itemBitmap = new Bitmap(Properties.Resources.TV);
                    break;
            }

            itemImage[indexNumber].Image = itemBitmap; //해당 인덱스에 이미지넣기
            itemImage[indexNumber].Size = new Size(100, 100); //사이즈 정하기
            itemImage[indexNumber].SizeMode = PictureBoxSizeMode.StretchImage;//이미지 모드 StretchImage로 정하기
            itemImage[indexNumber].Location = new Point(24, 65); //위치 정하기 
            itemImage[indexNumber].BackColor = Color.Transparent;//배경 투명으로 설정

            itemImage[indexNumber].Tag = indexNumber; //버튼의 태그값을 그대로 픽쳐박스의 태그값으로 사용하기

            mainBox.Controls.Add(itemImage[indexNumber]);//폼에 올리기

            
            (sender as Button).Enabled = false; //버튼 비활성화

            //이벤트 부여하기
            itemImage[indexNumber].MouseDown += new MouseEventHandler(Item_MouseDown);//마우스 다운 이벤트 추가
            itemImage[indexNumber].MouseMove += new MouseEventHandler(Item_MouseMove);//마우스 무브 이벤트 추가
            itemImage[indexNumber].PreviewKeyDown += new PreviewKeyDownEventHandler(Item_KeyDown);//키다운 이벤트 추가 

            //포커스주기
            itemImage[indexNumber].Focus();
            focusedPictureBox = itemImage[indexNumber];

            itemLocation[indexNumber] = new Point(24, 65);

            itemBitmap = null;//bmp 정리
            allItem += 1; //사용된 아이템 갯수 증가
        }

        private void Item_MouseDown(object sender, MouseEventArgs e) //마우스로 눌렀을 때 이벤트
        {
            mousePos = e.Location;
            (sender as PictureBox).Focus();
            focusedPictureBox = (sender as PictureBox);
            tempIndex = Convert.ToInt32((sender as PictureBox).Tag);
            itemLocation[tempIndex] = (sender as PictureBox).Location;
        }

        private void Item_MouseMove(object sender, MouseEventArgs e) //마우스누른채로 움직였을 때 이벤트
        {
            if (e.Button == MouseButtons.Left)
            {
                int pointX = e.X - mousePos.X;
                int pointY = e.Y - mousePos.Y;
                (sender as PictureBox).Location = new Point((sender as PictureBox).Left + pointX, (sender as PictureBox).Top + pointY);

                tempIndex = Convert.ToInt32((sender as PictureBox).Tag);
                itemLocation[tempIndex] = (sender as PictureBox).Location;
            }
        }

        private void Item_KeyDown(object sender, PreviewKeyDownEventArgs e) //키보드 누를 때 이벤트
        {

            if (e.KeyCode == Keys.Right)
            {
                Point p = new Point((sender as PictureBox).Location.X + 20, (sender as PictureBox).Location.Y);
                (sender as PictureBox).Location = p;

                itemLocation[tempIndex] = (sender as PictureBox).Location;
            }
            else if (e.KeyCode == Keys.Left)
            {
                Point p = new Point((sender as PictureBox).Location.X - 20, (sender as PictureBox).Location.Y);
                (sender as PictureBox).Location = p;

                int tempIndex = Convert.ToInt32((sender as PictureBox).Tag);
                itemLocation[tempIndex] = (sender as PictureBox).Location;
            }
            if ((e.KeyCode == Keys.Up))
            {
                Point p = new Point((sender as PictureBox).Location.X, (sender as PictureBox).Location.Y - 20);
                (sender as PictureBox).Location = p;

                int tempIndex = Convert.ToInt32((sender as PictureBox).Tag);
                itemLocation[tempIndex] = (sender as PictureBox).Location;
            }
            if ((e.KeyCode == Keys.Down))
            {
                Point p = new Point((sender as PictureBox).Location.X, (sender as PictureBox).Location.Y + 20);
                (sender as PictureBox).Location = p;

                int tempIndex = Convert.ToInt32((sender as PictureBox).Tag);
                itemLocation[tempIndex] = (sender as PictureBox).Location;
            }
            if (e.KeyCode == Keys.Space)
            {
                for (int i = 0; i < 10; i++)
                {
                    Point p = new Point((sender as PictureBox).Location.X, (sender as PictureBox).Location.Y - i);
                    (sender as PictureBox).Location = p;

                    int tempIndex = Convert.ToInt32((sender as PictureBox).Tag);
                    itemLocation[tempIndex] = (sender as PictureBox).Location;
                    Thread.Sleep(10);
                }
                for (int i = 0; i < 10; i++)
                {
                    Point p = new Point((sender as PictureBox).Location.X, (sender as PictureBox).Location.Y + i);
                    (sender as PictureBox).Location = p;

                    int tempIndex = Convert.ToInt32((sender as PictureBox).Tag);
                    itemLocation[tempIndex] = (sender as PictureBox).Location;
                    Thread.Sleep(10);
                }
            }

        }

        private void Button14_Click(object sender, EventArgs e)
        {
            //투명도가 0이 아닌것만 골라서하기 ㅇㅇ 
             origin = (Bitmap)focusedPictureBox.Image;
             Bitmap red = origin;
            Color ben = System.Drawing.ColorTranslator.FromHtml("#434343"); //테두리 색 : 6e6e6e

            for (int y = 0; y< origin.Width; y++)
                {
                for(int x = 0; x< origin.Height; x++)
                {
                    if (origin.GetPixel(y, x).A == 255 && origin.GetPixel(y, x) != ben)
                    {
                        try
                        {
                            red.SetPixel(y, x, curcolor);
                        }
                        catch
                        {
                            red.SetPixel(y, x, Color.Blue);
                        }
                    }
                }
                }
            focusedPictureBox.Image = red;
            
        } //색칠하기

        private void Color_Click(object sender, EventArgs e)
        {
            curcolor = (sender as PictureBox).BackColor;
            this.Button14_Click(sender, e);
        }

        private void Button13_Click(object sender, EventArgs e) //배치완료 버튼
        {


            if (allItem < 12)
            {
                MessageBox.Show("가구를 모두 배치해주세요 !", "가구 수가 너무 적어요 ! ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Bitmap[] send = new Bitmap[itemImage.Length];

                for (int i = 0; i < itemImage.Length; i++)
                {
                    send[i] = (Bitmap)itemImage[i].Image;
                }


                String[] temp = ColorCount.Classfication(send);

                ColorResultForm resultForm = new ColorResultForm(temp);

                resultForm.Show();
                this.Hide();
            }

        }

   
    }
}
