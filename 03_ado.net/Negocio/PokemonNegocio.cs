using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using negocio;
using Negocio;

namespace negocio
{
    public class PokemonNegocio
    {
        public List<Pokemon> listar()
        {
            List<Pokemon> lista = new List<Pokemon>();
            SqlConnection conexion = new SqlConnection(); //conectarse
            SqlCommand comando = new SqlCommand(); //acciones
            SqlDataReader lector; // datos obtenidos

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Numero, Nombre, P.Descripcion, urlImagen, E.Descripcion As Tipo, D.Descripcion As Debilidad, P.IdTipo, P.IdDebilidad, P.Id From Pokemons P, Elementos E, Elementos D Where E.Id = P.IdTipo And D.Id = P.IdDebilidad";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read()) 
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)lector["Id"];
                    aux.Numero = (int)lector["Numero"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    if (!(lector["UrlImagen"] is DBNull))
                    {
                        aux.urlImagen = (string)lector["urlImagen"];
                    }
                    aux.Tipo = new Elemento();
                    aux.Tipo.id = (int)lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.id = (int)lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)lector["Debilidad"];

                    lista.Add(aux);
                }
                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void agregar(Pokemon agregarPokemon)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert Into POKEMONS (Numero, Nombre, Descripcion, Activo, IdTipo, IdDebilidad, UrlImagen) Values(" + agregarPokemon.Numero + ", '" + agregarPokemon.Nombre + "', '" + agregarPokemon.Descripcion + "', 1, @idTipo, @idDebilidad, @UrlImagen)");
                datos.setearParametro("@idTipo", agregarPokemon.Tipo.id);
                datos.setearParametro("@idDebilidad", agregarPokemon.Debilidad.id);
                datos.setearParametro("@UrlImagen", agregarPokemon.urlImagen);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Pokemon modificarPokemon)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update POKEMONS Set Numero = @Numero, Nombre = @Nombre, Descripcion = @Descripcion, UrlImagen = @Imagen, IdTipo = @IdTipo, IdDebilidad = @IdDebilidad Where Id = @Id");
                datos.setearParametro("@Numero", modificarPokemon.Numero);
                datos.setearParametro("@Nombre", modificarPokemon.Nombre);
                datos.setearParametro("@Descripcion", modificarPokemon.Descripcion);
                datos.setearParametro("@Imagen", modificarPokemon.urlImagen);
                datos.setearParametro("@IdTipo", modificarPokemon.Tipo.id);
                datos.setearParametro("@IdDebilidad", modificarPokemon.Debilidad.id);
                datos.setearParametro("@Id", modificarPokemon.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
