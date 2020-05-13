using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moondo
{
    class ColorCount
    {
       
       //빨주노초파남보 마젠타로 바꾸기

        public static String[] Classfication(Bitmap[] bitmaps) //bitmap으로 가져와서 분석하기
        {
            int red = 0, blue = 0, yellow = 0, green = 0, orange = 0, brown = 0, purple = 0, margenta = 0;
            int white = 0, gray = 0, black = 0; //색채검사에 필요하지않는 white와 graydhk black은 제거한다

            Bitmap bitmap;

            #region classfication

            for (int i = 0; i < bitmaps.Length; i++)
            {
                bitmap = bitmaps[i];
                for (int y = 0; y < bitmap.Height; y++) // bmp에 저장
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        int r = bitmap.GetPixel(x, y).R;
                        int g = bitmap.GetPixel(x, y).G;
                        int b = bitmap.GetPixel(x, y).B;

                        if (r > 177) //r이 177보다 크다면 
                        {
                            if (g > 177)
                            {
                                if (b > 177)
                                {
                                    white += 255;
                                }
                                else if (b > 113)
                                {
                                    gray += 255;
                                }
                                else if (b > 49)
                                {
                                    yellow += 178;
                                }
                                else
                                {
                                    yellow += 50;
                                }
                            }
                            else if (g > 113)
                            {
                                if (b > 177)
                                {
                                    margenta += 178;
                                }
                                else if (b > 113)
                                {
                                    margenta += 0;
                                }
                                else if (b > 49)
                                {
                                    orange += 50;
                                }
                                else
                                {
                                    orange += 0;
                                }
                            }
                            else if (g > 49)
                            {
                                if (b > 177)
                                {
                                    purple += 178;
                                }
                                else if (b > 113)
                                {
                                    margenta += 50;
                                }
                                else
                                {
                                    orange += 114;
                                }
                            }
                            else
                            {
                                if (b > 177)
                                {
                                    purple += 178;
                                }
                                else if (b > 113)
                                {
                                    margenta += 178;
                                }
                                else if (b > 49)
                                {
                                    margenta += 114;
                                }
                                else
                                {
                                    red += 178;
                                }
                            }
                        }
                        else if (r > 113)
                        {
                            if (g > 177)
                            {
                                if (b > 177)
                                {
                                    blue += 0;
                                }
                                else
                                {
                                    green += 114;
                                }
                            }
                            else if (g > 113)
                            {
                                if (b > 177)
                                {
                                    blue += 114;
                                }
                                else if (b > 113)
                                {
                                    gray += 255;
                                }
                                else
                                {
                                    green += 50;
                                }
                            }
                            else if (g > 49)
                            {
                                if (b > 113)
                                {
                                    purple += 50;
                                }
                                else if (b > 49)
                                {
                                    gray += 255;
                                }
                                else
                                {
                                    brown += 118;
                                }
                            }
                            else
                            {
                                if (b > 113)
                                {
                                    purple += 178;
                                }
                                else if (b > 49)
                                {
                                    purple += 0;
                                }
                                else
                                {
                                    red += 178;
                                }
                            }
                        }
                        else if (r > 49)
                        {
                            if (g > 177)
                            {
                                if (b > 177)
                                {
                                    blue += 178;
                                }
                                else
                                {
                                    green += 114;
                                }
                            }
                            else if (g > 113)
                            {
                                if (b > 113)
                                {
                                    blue += 50;
                                }
                                else
                                {
                                    green += 50;
                                }
                            }
                            else if (g > 49)
                            {
                                if (b > 49)
                                {
                                    gray += 255;
                                }
                                else
                                {
                                    brown += 50;
                                }
                            }
                            else
                            {
                                if (b > 177)
                                {
                                    purple += 178;
                                }
                                else if (b > 49)
                                {
                                    purple += 114;
                                }
                                else
                                {
                                    brown += 50;
                                }
                            }
                        }
                        else
                        {
                            if (g > 177)
                            {
                                if (b > 177)
                                {
                                    blue += 114;
                                }
                                else if (b > 49)
                                {
                                    green += 114;
                                }
                                else
                                {
                                    green += 178;
                                }
                            }
                            else if (g > 113)
                            {
                                if (b > 113)
                                {
                                    blue += 114;
                                }
                                else if (b > 49)
                                {
                                    green += 50;
                                }
                                else
                                {
                                    green += 178;
                                }
                            }
                            else if (g > 49)
                            {
                                if (b > 113)
                                {
                                    blue += 114;
                                }
                                else if (b > 49)
                                {
                                    green += 0;
                                }
                                else
                                {
                                    green += 178;
                                }
                            }
                            else
                            {
                                if (b > 49)
                                {
                                    blue += 178;
                                }
                                else
                                {
                                    black += 255;
                                }
                            }
                        }
                    }
                }
            }
             #endregion



            //여기까지 반복
            int[] colorArray = new int[9]; //9가지의 색으로 분류할것

            colorArray[0] = red;
            colorArray[1] = blue;
            colorArray[2] = yellow;
            colorArray[3] = green;
            colorArray[4] = orange;
            colorArray[5] = brown;
            colorArray[6] = purple;
            colorArray[7] = margenta;


            //첫번째로 많은 색 찾기
            int fst = 0, fcount = 8; 
            for (int i = 0; i < colorArray.Length; i++)
            {
                if (fst < colorArray[i])
                {
                    fst = colorArray[i];
                    fcount = i;
                }
            }
            colorArray[fcount] = 0; // 첫번째로 많은색의 값을 0으로 설정

            //두번째로 많은 색 찾기
            int snd = 0, scount = 8;
            for (int i = 0; i < colorArray.Length; i++)
            {
                if (snd < colorArray[i])
                {
                    snd = colorArray[i];
                    scount = i;
                }
            }
            colorArray[scount] = 0;

            //세번째로 많은 색 찾기
            int trd = 0, tcount = 8;
            for (int i = 0; i < colorArray.Length; i++)
            {
                if (trd < colorArray[i])
                {
                    trd = colorArray[i];
                    tcount = i;
                }
            }

            //string 형으로 return해주기위해 index에 맞는 색 찾아서 return 
            string[] result = new string[3];
            if (fcount == 0) result[0] = "red";
            else if (fcount == 1) result[0] = "blue";
            else if (fcount == 2) result[0] = "yellow";
            else if (fcount == 3) result[0] = "green";
            else if (fcount == 4) result[0] = "orange";
            else if (fcount == 5) result[0] = "brown";
            else if (fcount == 6) result[0] = "purple";
            else if (fcount == 7) result[0] = "margenta";

            if (scount == 0) result[1] = "red";
            else if (scount == 1) result[1] = "blue";
            else if (scount == 2) result[1] = "yellow";
            else if (scount == 3) result[1] = "green";
            else if (scount == 4) result[1] = "orange";
            else if (scount == 5) result[1] = "brown";
            else if (scount == 6) result[1] = "purple";
            else if (scount == 7) result[1] = "margenta";

            if (tcount == 0) result[2] = "red";
            else if (tcount == 1) result[2] = "blue";
            else if (tcount == 2) result[2] = "yellow";
            else if (tcount == 3) result[2] = "green";
            else if (tcount == 4) result[2] = "orange";
            else if (tcount == 5) result[2] = "brown";
            else if (tcount == 6) result[2] = "purple";
            else if (tcount == 7) result[2] = "margenta";

            return result;
        }













    }


}
