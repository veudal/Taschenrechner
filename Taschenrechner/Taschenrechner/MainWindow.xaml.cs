using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Taschenrechner.Entities;

namespace Taschenrechner
{
    public partial class MainWindow : Window
    {
        bool nurEinKomma = true;
        private bool _shouldReset = false;
        List<Term> alleZahlen = new List<Term>();
        private string letzteEingabe;
        bool istBerechnet = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_ClickGleich(object sender, RoutedEventArgs e)
        {
            nurEinKomma = true;
            _shouldReset = true;
            addTerm("=");

            double result = 0;

            foreach(var term in alleZahlen)
            {
                switch(term.Operator)
                {
                    case null:
                    case "":
                        result = term.Zahl;
                        break;
                    case "+":
                        result = result + term.Zahl;
                        break;
                    case "-":
                        result = result - term.Zahl;
                        break;
                    case "*":
                        result = result * term.Zahl;
                        break;
                    case "/":
                        if (term.Zahl == 0)
                            MessageBox.Show("Teilen mit null ist nicht möglich, du Depp!");
                        else
                            result = result / term.Zahl;
                        break;
                }
            }

            textBlockAusgabe.Text = result.ToString();
            alleZahlen.Clear();
            istBerechnet = true;
        }

        private void Ausgabe(string v)
        {
            LesefeldAusgabe.Text = LesefeldAusgabe.Text + v;
        }

        private void addTerm(string oper)
        {
            if (istBerechnet)
            {
                LesefeldAusgabe.Text = string.Empty;
                istBerechnet = false;
            }
                if (string.IsNullOrEmpty(letzteEingabe))
                return;
            else if (letzteEingabe == "Zahl")
            {
                var aktuelleZahl = double.Parse(textBlockAusgabe.Text);
                var term = new Term();
                term.Zahl = aktuelleZahl;

                // Wenn die Liste leer ist, dann packe nur die Zahl in das erste Element
                if (alleZahlen.Count() == 0)
                    alleZahlen.Add(term);
                // Wenn die Liste schon ELmente enthält, dann müssen wir die Zahl in das letzte Listenelement ablegen zu dem Operator.
                else
                    alleZahlen.Last().Zahl = aktuelleZahl;

                // Wenn der Oeprator nicht "=" ist, dann müssen wir schon das nächste Element nur mit dem Oeprator vorbereiten
                if (oper != "=")
                {
                    var nextTerm = new Term();
                    nextTerm.Operator = oper;
                    alleZahlen.Add(nextTerm);
                }
                
                LesefeldAusgabe.Text = LesefeldAusgabe.Text + " " + oper + " ";

            }
            else
            {
                if (alleZahlen.Count()>0)
                {
                    alleZahlen.Last().Operator = oper;
                    LesefeldAusgabe.Text = LesefeldAusgabe.Text.Substring(0, LesefeldAusgabe.Text.Length - 2) + oper + " ";
                }
            }

            letzteEingabe = "Operator";

        }

        private void Button_MinusClicked(object sender, RoutedEventArgs e)
        {
            addTerm("-");
            _shouldReset = true;
            nurEinKomma = true;
        }
        private void Button_PlusClicked(object sender, RoutedEventArgs e)
        {
            addTerm("+");
            _shouldReset = true;
            nurEinKomma = true;
        }
        private void Button_MalClicked(object sender, RoutedEventArgs e)
        {
            addTerm("*");
            _shouldReset = true;
            nurEinKomma = true;
        }
        private void Button_GeteiltClicked(object sender, RoutedEventArgs e)
        {
            addTerm("/");
            _shouldReset = true;
            nurEinKomma = true;
        }


        private void ZifferAnhängen(string z)
        {
            if (istBerechnet)
            {
                LesefeldAusgabe.Text = string.Empty;
                istBerechnet = false;
            }

            if (_shouldReset)
            {
                textBlockAusgabe.Text = string.Empty;
                _shouldReset = false;
            }

            if (textBlockAusgabe.Text == "0") 
            {
                textBlockAusgabe.Text = string.Empty;
            }

            textBlockAusgabe.Text = textBlockAusgabe.Text + z;
            letzteEingabe = "Zahl";
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            ZifferAnhängen("1");
            Ausgabe("1");
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            ZifferAnhängen("2");
            Ausgabe("2");
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            ZifferAnhängen("3");
            Ausgabe("3");
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            ZifferAnhängen("4");
            Ausgabe("4");
        }

        private void Button_Click5(object sender, RoutedEventArgs e)
        {
            ZifferAnhängen("5");
            Ausgabe("5");
        }

        private void Button_Click6(object sender, RoutedEventArgs e)
        {
            ZifferAnhängen("6");
            Ausgabe("6");
        }

        private void Button_Click7(object sender, RoutedEventArgs e)
        {
            ZifferAnhängen("7");
            Ausgabe("7");
        }

        private void Button_Click8(object sender, RoutedEventArgs e)
        {
            ZifferAnhängen("8");
            Ausgabe("8");
        }

        private void Button_Click9(object sender, RoutedEventArgs e)
        {
            ZifferAnhängen("9");
            Ausgabe("9");
        }

        private void Button_Click0(object sender, RoutedEventArgs e)
        {
            ZifferAnhängen("0");
            Ausgabe("0");
        }

        private void Button_ClickKomma(object sender, RoutedEventArgs e)
        {
            if (nurEinKomma == true) 
            {
                if (istBerechnet)
                {
                    LesefeldAusgabe.Text = string.Empty;
                    istBerechnet = false;
                }

                if (_shouldReset)
                {
                    textBlockAusgabe.Text = string.Empty;
                    _shouldReset = false;
                }

                if (textBlockAusgabe.Text == "0")
                {
                    textBlockAusgabe.Text = string.Empty;
                }

                textBlockAusgabe.Text = textBlockAusgabe.Text + ",";
                Ausgabe(",");
                nurEinKomma = false;
            }

            else 
            {
                MessageBox.Show("In einer Ziffer kann es nur ein Komma geben!");
            }
        }
    }
}
