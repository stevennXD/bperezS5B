using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bperezS5B.Models
{
    public class PersonaRepository
    {
        string _dbPath;
        private SQLiteConnection conn;
        public string StatusMessage { get; set; }

        private void Init()
        {
            if (conn is not null)
                return;

            conn = new(_dbPath);
            conn.CreateTable<Persona>();
        }

        public PersonaRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void AddNewPerson(string nombre)
        {
            int result = 0;
            try
            {
                Init();

                if (string.IsNullOrEmpty(nombre))
                    throw new Exception("Nombre requerido");

                Persona person = new() { Name = nombre };
                result = conn.Insert(person);

                StatusMessage = string.Format("{0} registro(s) agregados (Nombre: {1})", result, nombre);
            }
            catch(Exception ex)
            {
                StatusMessage = string.Format("Error al agregar {0}. Error: {1}", nombre, ex.Message);
            }

        }

        public List<Persona> GetAllPeople()
        {
            try
            {
                Init();

                return conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error al obtener los datos. {0}", ex.Message);
            }

            return new List<Persona>();
        }

        public void UpdatePerson(int id, string nombre)
        {
            try
            {
                Init();

                var personToUpdate = conn.Find<Persona>(id);
                if (personToUpdate == null)
                    throw new Exception("Persona no encontrada");

                personToUpdate.Name = nombre;
                int result = conn.Update(personToUpdate);

                StatusMessage = string.Format("{0} record(s) updated (Id: {1}, Nombre: {2})", result, id, nombre);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error al actualizar persona. Error: {0}", ex.Message);
            }
        }

        public void DeletePerson(int id)
        {
            try
            {
                Init();

                var personToDelete = conn.Find<Persona>(id);
                if (personToDelete == null)
                    throw new Exception("Persona no encontrada");

                int result = conn.Delete(personToDelete);
                StatusMessage = string.Format("{0} record(s) deleted (Id: {1})", result, id);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error al eliminar persona. Error: {0}", ex.Message);
            }
        }
    }
}
