namespace CalculatorIMC;

public partial class ResultadoIMC : ContentPage
{
    private float pesoN;
    private float altura;
    private string genero;
    private IMC imc = new IMC();

    public ResultadoIMC(float p, float a, string g)
	{
		InitializeComponent();
        pesoN = p;
        altura = a;
        genero= g;
	}

    private void MostrarIMC()
    {
        try
        {
            lblResultado.Text = imc.CalcularIMC(pesoN, altura).ToString("N1");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void CambiarColor(string peso)
    {
        try
        {
            lblNivel.TextColor = (peso == "normal") ? Color.FromRgb(52, 152, 219) : Colors.Red;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void ModificarTexto(string pesoL, string gen)
    {
        try
        {
            lblNivel.Text = pesoL.ToUpper();
            lblTxtRango.Text = "Rango " + pesoL + " de IMC";
            lblValorRango.Text = imc.RangoNormal(gen) + " kg/m2";

            lblMensaje.Text = (pesoL == "normal") ? "Tienes un peso corporal " + pesoL + ". ¡Buen trabajo!" :
                                                    "Tienes un peso corporal " + pesoL + ". ¡Debes mejorar!";
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        try
        {
            MostrarIMC();
            string ps = imc.RangoIMC(genero, Convert.ToSingle(lblResultado.Text));
            CambiarColor(ps);
            ModificarTexto(ps, genero);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void btnRegresar_Pressed(object sender, EventArgs e)
    {
		Navigation.PushModalAsync(new MainPage());
    }
}