using MaterialSkin;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BruteForcePasswordFinder
{
  public partial class FormMain : MaterialSkin.Controls.MaterialForm
  {

    protected override CreateParams CreateParams
    {
      get
      {
        const int CS_DROPSHADOW = 0x39000;
        CreateParams cp = base.CreateParams;
        cp.ClassStyle |= CS_DROPSHADOW;
        return cp;
      }
    }

    public FormMain()
    {
      InitializeComponent();
      var skinManager = MaterialSkinManager.Instance;
      skinManager.AddFormToManage(this);
      skinManager.Theme = MaterialSkinManager.Themes.DARK;
      skinManager.ColorScheme = new ColorScheme(Primary.LightGreen800, Primary.LightGreen900, Primary.LightGreen500, Accent.LightGreen200, TextShade.WHITE);

    }

    private void Check(string pch, string charset)
    {
      charset.Split(new[] { ',' }).ToList<string>();
      foreach (char oneCharacter in charset)
      {
        string searchedCharacter = Convert.ToString(oneCharacter);
        if (searchedCharacter == pch)
        {
          txtResult.Text = txtResult.Text + " \n Trying.. [ " + oneCharacter + " ]" + Environment.NewLine;
          txtResult.Text = txtResult.Text + " \n ###### Matched [ " + oneCharacter + " ] ######" + Environment.NewLine;
          break;
        }
        else
        {
          txtResult.Text = txtResult.Text + " \n Trying.. [ " + oneCharacter + " ]" + Environment.NewLine;
        }
      }
    }



    private string BruteForce()
    {
      string passwordToBeFound = txtPassword.Text;
      string minuscules = "abcdefghijklmnopqrstuvwxyz";
      string majuscules = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
      string numbers = "0123456789";
      string specialCharacters = "!@#$%^&*(~[-+:=;'{<>_?/,.|¿¡}'])";
      string result = string.Empty;
      txtResult.Text = "[+][+] Starting BruteForce...";
      passwordToBeFound.Split(new[] { ',' }).ToList<string>();
      for (int eachLetter = 0; eachLetter <= passwordToBeFound.Length - 1; eachLetter++)
      {
        string oneLetter = Convert.ToString(passwordToBeFound[eachLetter]);
        if (minuscules.Contains(oneLetter))
        {
          Check(oneLetter, minuscules);
          result += oneLetter;
        }
        else if (majuscules.Contains(oneLetter))
        {
          Check(oneLetter, majuscules);
          result += oneLetter;
        }
        else if (numbers.Contains(oneLetter))
        {
          Check(oneLetter, numbers);
          result += oneLetter;
        }
        else
        {
          Check(oneLetter, specialCharacters);
          result += oneLetter;
        }
      }

      return result;
    }

    private void MaterialRaisedButton1_Click(object sender, EventArgs e)
    {
      textBox1.Text = " All Matched - Password Found: " + BruteForce();
    }
  }
}
