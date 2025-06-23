using PersonalExpenses.Pages;

namespace PersonalExpenses
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        public List<RBTN_Categorias> Items => new List<RBTN_Categorias> 
        {
            new RBTN_Categorias{Id=1, Categoria = "Inversiones"},
            new RBTN_Categorias{Id=2, Categoria = "Gastos"}
        };


        private void AddExpense(object? sender, EventArgs e)
        {
            //count++;

            //if (count == 1)
            //    lblPrueba.Text = $"Clicked {count} time";
            //else
            //    lblPrueba.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(lblPrueba.Text = txtCantidadGasto.Text);
        }
    }
}
