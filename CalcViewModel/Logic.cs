using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;
using System.Windows;

namespace CalcViewModel
{
    public class Logic : INotifyPropertyChanged
    {
        public string _expression;
        public string _current_number; 

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public Logic()
        {
            _expression = "";
            _current_number = "";
        }
        private double CalculateResult(string Exp)
        {
            List<string> NumbersAndOperands = null;
            double Result = 0;

            NumbersAndOperands = Regex.Split(Exp, "(?<=[-+*/()])|(?=[-+*/()])").ToList();

            for (int i = 0; i < NumbersAndOperands.Count; i++)
            {
                if (NumbersAndOperands[i] == "*" || NumbersAndOperands[i] == "/")
                {
                    switch (NumbersAndOperands[i])
                    {
                        case "*":
                            NumbersAndOperands[i + 1] =
                                (double.Parse(NumbersAndOperands[i-1]) * double.Parse(NumbersAndOperands[i + 1])).ToString();
                            Result = double.Parse(NumbersAndOperands[i + 1]);
                            NumbersAndOperands.RemoveAt(i - 1);
                            NumbersAndOperands.RemoveAt(i - 1);
                            i = 0;
                            break;
                        case "/":
                            NumbersAndOperands[i + 1] =
                                (double.Parse(NumbersAndOperands[i - 1]) / double.Parse(NumbersAndOperands[i + 1])).ToString();
                            Result = double.Parse(NumbersAndOperands[i + 1]);
                            NumbersAndOperands.RemoveAt(i - 1);
                            NumbersAndOperands.RemoveAt(i - 1);
                            i = 0;
                            break;
                        default:
                            break;
                    }
                }
            }
            for (int i = 0; i < NumbersAndOperands.Count; i++)
            {
                switch (NumbersAndOperands[i])
                {
                    case "+":
                        Result = double.Parse(NumbersAndOperands[i - 1]) + 
                            double.Parse(NumbersAndOperands[i + 1]);
                        NumbersAndOperands[i + 1] = Result.ToString();
                        break;
                    case "-":
                        Result = double.Parse(NumbersAndOperands[i - 1]) +
                            double.Parse(NumbersAndOperands[i + 1]);
                        NumbersAndOperands[i + 1] = Result.ToString();
                        break;

                }
            }
            return Result;
        }

        public string Expression
        {
            get { return _expression; }
            set
            {
                _expression = value;
                OnPropertyChanged("Expression");
            }
        }
        public string Current_number
        {
            get { return _current_number; }
            set
            {
                _current_number = value;
                OnPropertyChanged("Current_number");
            }
        }
        RelayCommand _one;
        public RelayCommand One
        {
            get
            {
                return _one ??
                  (_one = new RelayCommand((ob) =>
                  {
                      try
                      {
                          Expression += "1";
                          Current_number += "1";
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }
        RelayCommand _two;
        public RelayCommand Two
        {
            get
            {
                return _two ??
                  (_two = new RelayCommand((ob) =>
                  {
                      try
                      {
                          Expression += "2";
                          Current_number += "2";
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }
        RelayCommand _three;
        public RelayCommand Three
        {
            get
            {
                return _three ??
                  (_three = new RelayCommand((ob) =>
                  {
                      try
                      {
                          Expression += "3";
                          Current_number += "3";
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }
        RelayCommand _four;
        public RelayCommand Four
        {
            get
            {
                return _four ??
                  (_four = new RelayCommand((ob) =>
                  {
                      try
                      {
                          Expression += "4";
                          Current_number += "4";
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }
        RelayCommand _five;
        public RelayCommand Five
        {
            get
            {
                return _five ??
                  (_five = new RelayCommand((ob) =>
                  {
                      try
                      {
                          Expression += "5";
                          Current_number += "5";
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }
        RelayCommand _six;
        public RelayCommand Six
        {
            get
            {
                return _six ??
                  (_six = new RelayCommand((ob) =>
                  {
                      try
                      {
                          Expression += "6";
                          Current_number += "6";
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }
        RelayCommand _seven;
        public RelayCommand Seven
        {
            get
            {
                return _seven ??
                  (_seven = new RelayCommand((ob) =>
                  {
                      try
                      {
                          Expression += "7";
                          Current_number += "7";
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }
        RelayCommand _eight;
        public RelayCommand Eight
        {
            get
            {
                return _eight ??
                  (_eight = new RelayCommand((ob) =>
                  {
                      try
                      {
                          Expression += "8";
                          Current_number += "8";
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }
        RelayCommand _nine;
        public RelayCommand Nine
        {
            get
            {
                return _nine ??
                  (_nine = new RelayCommand((ob) =>
                  {
                      try
                      {
                          Expression += "9";
                          Current_number += "9";
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }
        RelayCommand _zero;
        public RelayCommand Zero
        {
            get
            {
                return _zero ??
                  (_zero = new RelayCommand((ob) =>
                  {
                      try
                      {
                          if (Current_number == "")
                          {
                              Expression += "0,";
                              Current_number += "0,";
                          }
                          else
                          {
                              Expression += "0";
                              Current_number += "0";
                          }
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }
        RelayCommand _point;
        public RelayCommand Point
        {
            get
            {
                return _point ??
                  (_point = new RelayCommand((ob) =>
                  {
                      try
                      {
                          if(Current_number == "")
                          {
                              Expression += "0,";
                              Current_number += "0,";
                          }
                          else
                          {
                              if (Current_number.Contains(","))
                              {
                                  MessageBox.Show("Ћишн€€ зап€та€");
                                  return;
                              }
                              Expression += ",";
                              Current_number += ",";
                          }
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }
        RelayCommand _addition;
        public RelayCommand Addition
        {
            get
            {
                return _addition ??
                  (_addition = new RelayCommand((ob) =>
                  {
                      try
                      {
                          if (Current_number != "")
                          {
                              Expression += "+";
                              Current_number = "";
                          }
                          else
                              return;
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }
        RelayCommand _division;
        public RelayCommand Division
        {
            get
            {
                return _division ??
                  (_division = new RelayCommand((ob) =>
                  {
                      try
                      {
                          if (Current_number != "")
                          {
                              Expression += "/";
                              Current_number = "";
                          }
                          else
                              return;
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }
        RelayCommand _subtraction;
        public RelayCommand Subtraction
        {
            get
            {
                return _subtraction ??
                  (_subtraction = new RelayCommand((ob) =>
                  {
                      try
                      {
                          if (Current_number != "")
                          {
                              Expression += "-";
                              Current_number = "";
                          }
                          else
                              return;
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }
        RelayCommand _multiplication;
        public RelayCommand Multiplication
        {
            get
            {
                return _multiplication ??
                  (_multiplication = new RelayCommand((ob) =>
                  {
                      try
                      {
                          if (Current_number != "")
                          {
                              Expression += "*";
                              Current_number = "";
                          }
                          else
                              return;
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }
        RelayCommand _fullRemove;
        public RelayCommand FullRemove
        {
            get
            {
                return _fullRemove ??
                  (_fullRemove = new RelayCommand((ob) =>
                  {
                      try
                      {
                          Expression = "";
                          Current_number = "";
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }
        RelayCommand _removeLastNumber;
        public RelayCommand RemoveLastNumber
        {
            get
            {
                return _removeLastNumber ??
                  (_removeLastNumber = new RelayCommand((ob) =>
                  {
                      try
                      {
                          Expression = Expression.Remove((Expression.Length - Current_number.Length),
                              Current_number.Length);
                          Current_number = "";
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }
        RelayCommand _removeLastSymbol;
        public RelayCommand RemoveLastSymbol
        {
            get
            {
                return _removeLastSymbol ??
                  (_removeLastSymbol = new RelayCommand((ob) =>
                  {
                      try
                      {
                          if (Expression.Length == 0 || Current_number.Length == 0)
                              return;
                          else
                          {
                              Expression = Expression.Remove(Expression.Length - 1);
                              Current_number = Current_number.Remove(Current_number.Length - 1);
                          }
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }
        RelayCommand _getResult;
        public RelayCommand GetResult
        {
            get
            {
                return _getResult ??
                  (_getResult = new RelayCommand((ob) =>
                  {
                      try
                      {
                          if (!char.IsDigit(Expression, Expression.Length - 1))
                          {
                              Expression = Expression.Remove(Expression.Length - 1);
                              Current_number = CalculateResult(Expression).ToString();
                          }
                          else
                              Current_number = CalculateResult(Expression).ToString();
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }
    }
}
