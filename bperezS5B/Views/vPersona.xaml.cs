using bperezS5B.Models;

namespace bperezS5B.Views;

public partial class vPersona : ContentPage
{
	public vPersona()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";

        App.personaRepo.AddNewPerson(txtNombre.Text);
        statusMessage.Text = App.personaRepo.StatusMessage;
    }

    private void btnObtener_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";

        List<Persona> people = App.personaRepo.GetAllPeople();
        listaPersona.ItemsSource = people;

    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";

        if (int.TryParse(txtId.Text, out int id))
        {
            App.personaRepo.UpdatePerson(id, txtNombre.Text);
            statusMessage.Text = App.personaRepo.StatusMessage;
            btnObtener_Clicked(sender, e); // Actualiza la lista despu�s de la actualizaci�n
        }
        else
        {
            statusMessage.Text = "Por favor ingrese un ID v�lido para actualizar.";
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";

        if (int.TryParse(txtId.Text, out int id))
        {
            App.personaRepo.DeletePerson(id);
            statusMessage.Text = App.personaRepo.StatusMessage;
            btnObtener_Clicked(sender, e); // Actualiza la lista despu�s de la eliminaci�n
        }
        else
        {
            statusMessage.Text = "Por favor ingrese un ID v�lido para eliminar.";
        }
    }
}