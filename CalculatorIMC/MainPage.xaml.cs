namespace CalculatorIMC;

public partial class MainPage : ContentPage
{
    private string genero = string.Empty;

    public MainPage()
	{
		InitializeComponent();
        
    }

    //---------------Mis metodos---------------

    //Cambiar color boton genero
    private void ColorBtnGenero(Frame fr1, Frame fr2, ImageButton btn1, ImageButton btn2, string g1, string g2)
    {
        try
        {
            if (g1 != g2 && g2 != string.Empty)
            {
                fr2.BackgroundColor = Color.FromRgb(133, 193, 233);
                btn2.Source = g2 + "_white.svg";

            }

            fr1.BackgroundColor = Color.FromRgb(255, 255, 255);
            btn1.Source = g1 + "_blue.svg";
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    //---------------Metodos de los botones---------------

    private void btnMen_Pressed(object sender, EventArgs e)
    {
        this.ColorBtnGenero(frameMen, frameWomen, btnMen, btnWomen, "men", this.genero);
        genero = "men";
    }

    private void btnWomen_Pressed(object sender, EventArgs e)
    {
        this.ColorBtnGenero(frameWomen, frameMen, btnWomen, btnMen, "women", this.genero);
        genero = "women";
    }

    private void btnCalcular_Pressed(object sender, EventArgs e)
    {
        if (genero != string.Empty && lblAltura.Text != "0" && lblPeso.Text != "0")
        {
            Navigation.PushModalAsync(new ResultadoIMC(Convert.ToSingle(lblPeso.Text), Convert.ToSingle(lblAltura.Text), genero));
        }
        else
        {
            DisplayAlert("Alerta", "Debes seleccionar todos los campos", "OK");
        }
    }
}