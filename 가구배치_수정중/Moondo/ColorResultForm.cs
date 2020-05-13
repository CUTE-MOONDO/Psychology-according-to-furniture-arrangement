using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moondo
{
    public partial class ColorResultForm : Form
    {
        public string[,] indata = new string[4, 2]; //조합에 대한 결과출력
        int index = 0;//결과 페이지

        String[] result;
        Bitmap[] colors = new Bitmap[3];

        string[] title = new string[] { "나는 어떤 사람인가?", "현재 내가 처한 상황은?", "목표달성을 위해 지금 나에게 필요한것은 ?","조화 관계" };
        string[] subitle = new string[] { "첫 번째 색상 : ", "두 번째 색상 : ", "세 번째 색상 : ", "보색 관계의 두 색상 : " };

        

        //첫번째 색 나는 진짜 어떤 사람인가
        string[] first = new string[]{
          "남을 따르기보다 먼저 앞서 이끄는 성격으로 사교적이며 지도력이 있다. 경쟁심이 강하고 정열적이다. 목표 달성, 성공이라는 말을 자주 언급하며, 계획이나 전략보다 결단력을 믿고 목표를 향해 행동한다. 끊임없이 에너지가 솟구치는 당신, 논리와 감정의 조화를 위해 노력하자.",
          "경쾌하고 낙천적인 성격으로 활기차고 행복한 기질을 가진 사람이다. 인생을 즐기면서 어느 곳이든지 능동적으로 참여해 주위 사람들을 즐겁게 한다. 지나친 활동은 피로를 부를 수 있다. 균형 있게 일의 순위를 정하고, 전체적인 상황을 살펴보려고 노력하자.",
          "이성적이고 논리적으로 인생을 바라보며, 지적이고 분석적이다. 지배하기보다 우월하기 위해 노력하며, 관심 있는 분야에서 전문성을 자랑한다. 말솜씨가 뛰어나 말이나 숫자 관련 일에 참여하며, 책임감과 권위를 필요로 하는 곳에 어울린다",
          "언제나 균형을 추구해 행동하기 전에 심사숙고하며 자발적으로 나서지 않는다. 능률적이고 성실하며, 깔끔하고 단정하다. 자연에 탄복하며 탁 트인 공간과 자연 소재 제품에 매력을 느낀다. 주변 상황이나 사람에 대해 지나친 조심성을 가진 당신, 변화의 필요성에 대해 생각해보자.",
          "겉으로 침착하고 차분한 모습으로 어려운 일도 수월하게 처리하며, 상황에 따라 참신한 상상력을 발휘한다. 빠른 결단과 행동으로 장애물에 대처하는 모습과 편안한 대화 방식은 인기 요인이 되며, 뛰어난 통찰력을 지니고 있어 자신의 목적이나 방향의식을 다른 사람에게 쉽게 반영시킬 수 있다. 너무 영적인 면에 치중하기보다 현실성 있는 아이디어를 창출하자.",
          "부드럽고 온화하며 쉽게 흥분하지 않는 성격은 다른 이들에게 소극적인 사람으로 보인다. 정신적인 면을 중요시해 진실함을 자산으로 여기며, 믿음직하고 충실하다. 안정된 에너지를 발산하는 당신과 함께하는 사람들은 편안함을 느낀다. 자신에 대한 지나친 몰입은 고립과 자신감 결여로 이어지니 주의하자.",
          "신비함과 정신적 세계에 관심이 많아 영적인 면을 활용하지만 현실에는 잘 적응한다. 가치 있는 봉사를 원하며, 고상하고 예술적 표현력이 뛰어나 예술, 종교 등의 활동을 직업으로 삼으면 좋다. 설정한 비전을 달성할 수 없을 것 같다는 자신감 부족을 이겨내자.",
          "친절하고 사려 깊은 사람으로 타인에게 사랑과 연민을 보낼 줄 아는 세상의 소금 같은 존재. 인생에 대한 성숙한 이해심으로 주위 사람들을 격려하고 지지하려 노력한다. 타인과의 협응력이 뛰어나 상담이나 간호사, 사회사업가 같이 타인을 보살피는 분야에 일하는 경우가 많다."
        };

        //두번째 색 내가 현재 어떤 상황에 처해 있는 지
        string[] second = new string[]
        {
            "나를 자극하고 분발시켜야 할 때. 몸이 지치지 않도록 신체적 힘을 기르고 에너지를 적절히 조절하며 인내심을 가지려 노력하자.",
            "내적으로 균형을 찾기 위해 노력할 때. 강압적 태도가 자주 보일 수 있으니 느긋하고 편안하게 나에게 시간을 주자.",
            "현재에 맞는 에너지를 표현할 때. 너무 앞선 아이디어는 불만족 상태를 야기할 수 있으니 현실을 인지하자.",
            "내면의 상처를 돌봐야 할 때. 감정을 억누르고 솔직한 표현을 어려워해 위축감을 느낄 수 있으니 나를 치유할 수 있는 무언가 혹은 누군가를 찾아보자.",
            "사람들과 조금 거리를 두어야 할 때. 당신의 에너지에 이끌린 사람들의 요구로 자신만의 공간을 침범당한 지금, 심신의 정화가 필요하다.",
            "침묵을 깨야 할 때. 고요함과 평화로운 외면은 강점이기도 하지만 지나치면 우울과 의기소침에 빠질 수 있으니 자기 표현력과 말하는 습관이 필요하다.",
            "자신을 믿고 성숙해져야 할 때. 뛰어난 능력에 비해 자긍심이 부족한 당신. 타인의 인정을 통해 자신을 찾기보다 성실하고 끈기 있는 상황 극복을 통해 성장해보자.",
            "나를 먼저 사랑해야 할 때. 타인에 대한 일방적인 지원과 협조는 나의 욕구에 대한 가치를 잊게 만들 수 있으니 의무적 보답은 자제하자.",
        };

        //세번째 색 내면적 비전
        string[] thirth = new string[]
        {
            "생각해둔 새로운 일에 대한 행동을 미루지 말고 현실에 집중해 기회를 잡자. 에너지가 고갈되어 재충전의 필요성을 알리는 것일 수도 있는데, 이때 파란색은 에너지 보충을 도울 수 있다.",
            "순간적 충동을 자제하고 신중하게 건설적으로 행동하자. 내적 위축으로 인한 선택이라면 용감한 행동력과 인생을 즐기려는 의지를 찾아야 한다.",
            "자신의 선택에 대해 긍정적이고 개방적으로 행동하자. 휴식의 필요성에 의해 선택될 수 있는데, 이때 충분한 태양빛을 받아보자. 또한 나의 지식을 유익하게 전달하고자 하는 욕구일 때 타고난 직감과 지혜를 활용하면 노력이 빛을 발할 것이다.",
            "편안한 사람들과의 의미 있는 관계 형성을 통해 나의 가치를 찾아보자. 인생을 즐거움을 찾고 새로운 시각으로 바라보는 계기를 통해 상실과 무기력에서 벗어날 수 있다.",
            "변화와 도전을 통해 인생의 성장을 도모하자. 인생의 시련과 장애물을 반기고 도전 정신으로 이겨나가면 활력과 강인함으로 보상된다.",
            "삶의 순리를 깨닫고 매일 매일의 현실에 평범함을 중요시하자. 생각이나 명상만이 전부가 아닌 일상 속에서 순조롭게 적응하는 융통성을 발휘해야 진정한 자유를 찾을 수 있다.",
            "타고난 능력을 실질적으로 사용할 수 있도록 개발하자. 특별한 치유력을 타인과 나누고 싶다면 자신을 믿고 그 능력을 갈고 닦아야 한다.",
            "이미 목표를 향해 노력 중이거나 어느 정도 수준에 도달한 상태. 이럴 때일수록 자만과 우월함에 사로잡히지 않도록 조심해야 사람들과의 관계에 문제가 생기지 않는다."
        };

        public ColorResultForm(String[] result)
        {
            InitializeComponent();
            this.result = result;
            init();
        }

        private void init()  //초기 작업
        {       

            Core(Coreset(result)); //조화 검색용

            Colorset(result); //주조색 검색용

            setColor();


            title_label.Text = title[index];
            subtitle_label.Text = subitle[index];
            pictureBox1.Image = colors[index];

            label2.Text = indata[index, 0];
            label1.Text = indata[index, 1];

            button1.Enabled = false;
        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            index -= 1;
            if (index == 0)
                button1.Enabled = false;
            button2.Enabled = true;
            title_label.Text = title[index];
            subtitle_label.Text = subitle[index];
            label2.Text = indata[index, 0];
            label1.Text = indata[index, 1];
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            index += 1;
            if (index == 3)
                button2.Enabled = false;
            button1.Enabled = true;
            title_label.Text = title[index];
            subtitle_label.Text = subitle[index];
            label2.Text = indata[index, 0];
            label1.Text = indata[index, 1];
            
        }

        private void Core(int data)
        {
            if (data == 0)
            {
                indata[3, 0] = "차가운 색 + 따뜻한 색";
                indata[3, 1] = "뚜렷한 특징이 없습니다";
            }
            else if (data == 11)
            {
                indata[3, 0] = "두 번째 색 + 세 번째 색";
                indata[3, 1] = "성공을 위한 노력이 나 자신을 위한 것이기보다는 현재 상황과 맞물려 있지만 도전 과제를 극복하면 바람직한 결과를 기대할 수 있다.";
            }
            else if (data == 101)
            {
                indata[3, 0] = "첫 번째 색 + 세 번째 색";
                indata[3, 1] = "나에게 맞는 장기적 목표를 잘 설정하여 인생의 성공 가능성이 높지만, 두 번째 색에서 드러난 장애 물을 극복해야 한다.";
            }
            else if (data == 110)
            {
                indata[3, 0] = "첫 번째 색 + 두 번째 색";
                indata[3, 1] = "성공을 위한 노력이 나 자신을 위한 것이기보다는 현재 상황과 맞물려 있지만 도전 과제를 극복하면 바람직한 결과를 기대할 수 있다.";
            }
            else if (data == 30)
            {
                indata[3, 0] = "따뜻한 색";
                indata[3, 1] = "외향적인 성향이며 수용력이 풍부하고 외부로부터 영향을 받기 쉬우며 사회적 환경에 보다 쉽게 빠져든다. 그리고 남의 의견에 영향을 받기 쉬우며 따뜻한 느낌과 강한 정서를 가지고 있다.";
            }
            else if (data == 3)
            {
                indata[3, 0] = "차가운 색";
                indata[3, 1] = "내성적인 성향이며 외부 세계에 대하여 독립된 태도를 가지고 있고 새로운 환경에 적응하는 것과 자유롭게 표현하는 것을 어려워한다. 정서적으로 차가우며 내성적이다. 또한 개방된 성격과 기질을 가진 사람들은 단순한 색을 선택하는 경향이 있다.";
            }
        } //색깔 검색용
        private int Coreset(string[] data)
        {
            int myColor = 0;
            if (data[0].Equals("red"))
            {
                if (data[1].Equals("brown"))
                {
                    myColor = 110;
                }
                else if (data[2].Equals("brown"))
                {
                    myColor = 101;
                }
                else
                    myColor = 0;
            }
            else if (data[0].Equals("blue"))
            {
                if (data[1].Equals("orange"))
                {
                    myColor = 110;
                }
                else if (data[2].Equals("orange"))
                {
                    myColor = 101;
                }
                else
                    myColor = 0;
            }
            else if (data[0].Equals("yellow"))
            {
                if (data[1].Equals("purple"))
                {
                    myColor = 110;
                }
                else if (data[2].Equals("purple"))
                {
                    myColor = 101;
                }
                else
                    myColor = 0;
            }
            else if (data[0].Equals("green"))
            {
                if (data[1].Equals("margenta"))
                {
                    myColor = 110;
                }
                else if (data[2].Equals("margenta"))//nullpoint error
                {
                    myColor = 101;
                }
                else
                    myColor = 0;
            }

            else if (data[0].Equals("brown"))
            {
                if (data[1].Equals("red"))
                {
                    myColor = 110;
                }
                else if (data[2].Equals("red"))
                {
                    myColor = 101;
                }
                else
                    myColor = 0;
            }
            else if (data[0].Equals("orange"))
            {
                if (data[1].Equals("blue"))
                {
                    myColor = 110;
                }
                else if (data[2].Equals("blue"))
                {
                    myColor = 101;
                }
                else
                    myColor = 0;
            }
            else if (data[0].Equals("purple"))
            {
                if (data[1].Equals("yellow"))
                {
                    myColor = 110;
                }
                else if (data[2].Equals("yellow"))
                {
                    myColor = 101;
                }
                else
                    myColor = 0;
            }
            else if (data[0].Equals("margenta"))
            {
                if (data[1].Equals("green"))
                {
                    myColor = 110;
                }
                else if (data[2].Equals("green"))
                {
                    myColor = 101;
                }
                else
                    myColor = 0;
            }
            if (myColor == 0)
            {
                if (data[1].Equals("red") && data[2].Equals("brown"))
                    myColor = 11;
                else if (data[1].Equals("brown") && data[2].Equals("red"))
                    myColor = 11;

                else if (data[1].Equals("blue") && data[2].Equals("orange"))
                    myColor = 11;
                else if (data[1].Equals("orange") && data[2].Equals("blue"))
                    myColor = 11;

                else if (data[1].Equals("yellow") && data[2].Equals("purple"))
                    myColor = 11;
                else if (data[1].Equals("purple") && data[2].Equals("yellow"))
                    myColor = 11;

                else if (data[1].Equals("margenta") && data[2].Equals("green"))
                    myColor = 11;
                else if (data[1].Equals("green") && data[2].Equals("margenta"))
                    myColor = 11;

                else
                {
                    int warm = 0, cold = 0;
                    for (int i = 0; i < data.Length; i++)
                    {
                        if (data[i].Equals("red")) warm += 1;
                        else if (data[i].Equals("margenta")) warm += 1;
                        else if (data[i].Equals("orange")) warm += 1;
                        else if (data[i].Equals("yellow")) warm += 1;

                        if (data[i].Equals("brown")) cold += 1;
                        else if (data[i].Equals("blue")) cold += 1;
                        else if (data[i].Equals("purple")) cold += 1;
                        else if (data[i].Equals("green")) cold += 1;
                    }

                    if (warm == cold)
                        myColor = 0;
                    else if (warm > cold)
                        myColor = 30;
                    else
                        myColor = 3;
                }
            }

            return myColor;
        }// 조합 검색용 

        private void Colorset(string[] data)
        {
            for (int i = 0; i < data.Length; i++)
                if (data[i].Equals("red"))
                {
                    indata[i, 0] = "빨간색";
                    if (i == 0)
                        indata[i, 1] = first[0];
                    else if (i == 1)
                        indata[i, 1] = second[0];
                    else
                        indata[i, 1] = thirth[0];
                }
                else if (data[i].Equals("blue"))
                {
                    indata[i, 0] = "파랑색";
                    if (i == 0)
                        indata[i, 1] = first[0];
                    else if (i == 1)
                        indata[i, 1] = second[0];
                    else
                        indata[i, 1] = thirth[0];
                }
                else if (data[i].Equals("yellow"))
                {
                    indata[i, 0] = "노란색";
                    if (i == 0)
                        indata[i, 1] = first[0];
                    else if (i == 1)
                        indata[i, 1] = second[0];
                    else
                        indata[i, 1] = thirth[0];
                }
                else if (data[i].Equals("green"))
                {
                    indata[i, 0] = "초록색";
                    if (i == 0)
                        indata[i, 1] = first[0];
                    else if (i == 1)
                        indata[i, 1] = second[0];
                    else
                        indata[i, 1] = thirth[0];
                }
                else if (data[i].Equals("orange"))
                {
                    indata[i, 0] = "주황색";
                    if (i == 0)
                        indata[i, 1] = first[0];
                    else if (i == 1)
                        indata[i, 1] = second[0];
                    else
                        indata[i, 1] = thirth[0];
                }
                else if (data[i].Equals("brown"))
                {
                    indata[i, 0] = "갈색";
                    if (i == 0)
                        indata[i, 1] = first[0];
                    else if (i == 1)
                        indata[i, 1] = second[0];
                    else
                        indata[i, 1] = thirth[0];
                }
                else if (data[i].Equals("purple"))
                {
                    indata[i, 0] = "보라색";
                    if (i == 0)
                        indata[i, 1] = first[0];
                    else if (i == 1)
                        indata[i, 1] = second[0];
                    else
                        indata[i, 1] = thirth[0];
                }
                else if (data[i].Equals("margenta"))
                {
                    indata[i, 0] = "분홍색";
                    if (i == 0)
                        indata[i, 1] = first[0];
                    else if (i == 1)
                        indata[i, 1] = second[0];
                    else
                        indata[i, 1] = thirth[0];
                }
        } //주조색 검색용

        private void setColor()
        {
            for (int i = 0; i < 3; i++)
            {
              //  colors[i] = new Bitmap(@"C:\Users\KJY\Desktop\살려조\논문\Moondo\Moondo\Image\color\" + result[i] + ".jpg");

                switch (result[i])
                {
                    case "blue":
                        colors[i] = new Bitmap(Properties.Resources.blue);
                        break;
                    case "brown":
                        colors[i] = new Bitmap(Properties.Resources.brown);
                        break;
                    case "green":
                        colors[i] = new Bitmap(Properties.Resources.green);
                        break;
                    case "magenta":
                        colors[i] = new Bitmap(Properties.Resources.magenta);
                        break;
                    case "orange":
                        colors[i] = new Bitmap(Properties.Resources.orange);
                        break;
                    case "purple":
                        colors[i] = new Bitmap(Properties.Resources.purple);
                        break;
                    case "red":
                        colors[i] = new Bitmap(Properties.Resources.red);
                        break;
                    case "yellow":
                        colors[i] = new Bitmap(Properties.Resources.yellow);
                        break;
                   default:
                        colors[i] = new Bitmap(Properties.Resources.blue);
                        break;
                }
            }

            pictureBox1.Image = colors[0];
            pictureBox2.Image = colors[1];
            pictureBox3.Image = colors[2];

        } //색깔 표시

        private void Button3_Click(object sender, EventArgs e)
        {

            LocationFuzzy location = new LocationFuzzy();
            string[] located = location.Run();

            LocationResultForm resultForm = new LocationResultForm(located);

            resultForm.Show();
            this.Hide();
        }
    }
}
