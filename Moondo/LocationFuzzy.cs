using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moondo
{
    class LocationFuzzy
    {
        Point[] itemLocations = new Point[12];

        Point[] edge = new Point[4] { new Point(0, 0), new Point(600, 0), new Point(0, 560), new Point(600, 560) };

        int box_width = 600;
        //1    2  모서리 배치
        //3    4


        string[] mbti = new string[4];


        public LocationFuzzy()
        {
            init();
        }

        private void init() //전처리작업 
        {
            this.itemLocations = TestForm.itemLocation;
            //원래라면 24,65 자리에 있음 ( +50 = 74,135)
            for (int i = 0; i < itemLocations.Length; i++)
            {
                itemLocations[i].X += 50; //+50해주는 이유 : picturebox가 사이즈가 100*100이니까, 그 중심을 선택하려면 50씩 가로 세로에 더해줘야함 
                itemLocations[i].Y += 50;
            }
        }

        public string[] Run()
        {
            mbti[0] = Step1();
            mbti[1] = Step2();
            mbti[2] = Step3();
            mbti[3] = Step4();

            Console.WriteLine(mbti[0] + " " + mbti[1] + " " + mbti[2] + " " + mbti[3]);//결과

            return mbti;
        }

        private string Step1() //외향 vs 내향 ( 컴퓨터2, 침대4 )
        {
            double count1 = 0, count2 = 0, result = 0;


            for (int i = 0; i < itemLocations.Length; i++)
            {
                if (i != 2 || i != 4)
                {
                    count1 += Euclidean(itemLocations[i], itemLocations[2]);//컴퓨터와의 거리 구함
                    //둘중에 적은것이 중심임
                }   count2 += Euclidean(itemLocations[i], itemLocations[4]);//침대와의 거리 구함

                 
            }

            result = (count1 < count2) ? count1 : count2; //작은것을 찾아야함

            if (result == count1) //나중에 바꿨으면 좋겠다
            {
                return "외향형";
            }
            else
            {
                return "내향형";
            }

        }
        private string Step2() // 감각 vs 직관 ( 한 모서리에 집중되어있는지 )
        {
            int[,] fuzzyArray = new int[4, 12];
            int[] count = new int[4];
            bool zic = false;

            for (int i = 0; i < fuzzyArray.GetLength(1); i++)
            {
                if (itemLocations[i].X < 300) //1또는 3
                {
                    if (itemLocations[i].Y < 270)
                    {
                        fuzzyArray[0, i] = 1;
                    }
                    else
                    {
                        fuzzyArray[2, i] = 1;
                    }
                }
                else // x>=300
                {
                    if (itemLocations[i].Y < 270)
                    {
                        fuzzyArray[1, i] = 1;
                    }
                    else
                    {
                        fuzzyArray[3, i] = 1;
                    }
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < fuzzyArray.GetLength(1); j++)
                {
                    count[i] += fuzzyArray[i, j];
                }
            }

            for (int i = 0; i < 4; i++)
            {
                if (count[i] > 6)
                {
                    zic = true;
                }
            }

            return (zic == true) ? "감각형" : "직관형";
          

        }
        private string Step3() //사고 vs 감정 ( 컴퓨터2, 소파8 )
        {
            double count1 = 0, count2 = 0, result = 0;


            for (int i = 0; i < itemLocations.Length; i++)
            {
                if (i != 2 || i != 4)
                {
                    count1 += Euclidean(itemLocations[i], itemLocations[2]);//컴퓨터와의 거리 구함
                    count2 += Euclidean(itemLocations[i], itemLocations[8]);//침대와의 거리 구함

                    //둘중에 적은것이 중심임
                }
            }

            result = (count1 < count2) ? count1 : count2; //작은것을 찾아야함

            if (result == count1) //나중에 바꿨으면 좋겠다
            {
                return "사고형";
            }
            else 
            {
                return "감정형";
            }
        }
        private string Step4() // 판단 vs 인식 ( 컴퓨터2, tv7  붙어있는지)
        {
            double distance = 0;

            distance = Euclidean(itemLocations[2], itemLocations[7]);

            //이 두 사이 거리가 2칸거리까지 안에있으면 붙어있는것으로 인식

            double twocell = (box_width / 3) * 1.5;

            return (distance < twocell) ? "판단형" : "인식형";
        }

        private double Euclidean(Point A, Point B)
        {

            return (double)Math.Sqrt(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2));

        } //유클리드 거리계산 

    }
}
