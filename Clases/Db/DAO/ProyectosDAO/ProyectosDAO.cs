using System;
using System.Data.OleDb;
using System.Windows.Forms;
using UtilesCs.Clases.Utilidades.Db;
using System.Collections.Generic;
using TasksBook.Clases.Comunes;
using TasksBook.Clases.DTO;

/// Horas empresa:          Las horas empresa son el 70% de las horas cliente (30% son beneficios)
/// Presupuesto disponible: El presupuesto disponible son las horas empresa multiplicadas por el coste/hora cliente (33,5). 
///                         ¿Por qué? Porque:
///                         - Si nos pagan 100 horas a 33,5 €/h = 3.350 €, el 70 % de esos 3.350€ son 2.345€,
///                         que es el presupuesto que tenemos si queremos ganar ese 30%.
///                         Es decir:
///                         Caixabank paga 3.350€ (100 horas * 33,5€/h)
///                         Queremos un beneficio del 30%, luego tenemos disponibles 3.350 * 0,7 = 2.345€
///                         TODAS nuestra cuentas irán contra esos 23.450€.

namespace TasksBook.Clases.DAO.Proyectos
{

    public class ProyectosDAO
    {

        public static string GetCampoDTOById(string campo, int Id)
        {
            return UtilesDb.GetDatoPorId(Conexion.GetConexion(), "Proyectos", campo, Id);
        }

        public static List<ProyectoDTO> GetAllDatos(bool ocultarCerrados = true)
        {
            return GetDatosByIdProyecto(-1, ocultarCerrados);
        }

        public static List<ProyectoDTO> GetDatosByIdProyecto(int idProyecto = -1, bool ocultarCerrados = true)
        {

            List<ProyectoDTO> lista = new List<ProyectoDTO>();
            string sql = "";

            //CalculosDAO.ActualizaTodosLosProyectos();

            sql = "";
            sql += "SELECT *";
            sql += "  FROM Proyectos";
            sql += " WHERE EsProyecto='S'";
            if(idProyecto!=-1)
                sql += " AND Id = " + idProyecto.ToString() + " ";
            if (ocultarCerrados)
                sql += " AND FCierre IS NULL";
            sql += " ORDER BY Proyecto";

            Globales.logger.WriteLog(sql);
            OleDbDataReader reader = UtilesDb.GetOleDbDataReader(Conexion.GetConexion(), sql);
            if (reader == null)
                return null;
            while (reader.Read())
            {
                ProyectoDTO dto = new ProyectoDTO();
                dto = ReaderToDTO(reader);
                lista.Add(dto);
            }
            reader.Close();
            return lista;

        }

        public static int GetIdByProyecto(string nombre) => UtilesDb.GetIdPorDato(Conexion.GetConexion(), "Proyectos", "Proyecto", nombre);

        public static double GetHorasCliente(string proyecto)
        {
            double horasPrevistas = 0;
            string sql = "";

            sql = "";
            sql += "SELECT HorasCliente";
            sql += "  FROM Proyectos";
            sql += " WHERE Proyecto = '" + proyecto + "'";

            Globales.logger.WriteLog(sql);
            OleDbDataReader reader = UtilesDb.GetOleDbDataReader(Conexion.GetConexion(), sql);
            if (reader == null)
                return 0;

            reader.Read();
            horasPrevistas = OleDbUtiles.GetDoubleFromReader(reader, "HorasCliente");
            reader.Close();

            return horasPrevistas;

        }

        public static double PresupuestoDisponible(string proyecto)
        {

            double horasDXC = 0;
            string sql = "";

            sql = "";
            sql += "SELECT PresupuestoDisponible";
            sql += "  FROM Proyectos";
            sql += " WHERE Proyecto = '" + proyecto + "'";

            Globales.logger.WriteLog(sql);
            OleDbDataReader reader = UtilesDb.GetOleDbDataReader(Conexion.GetConexion(), sql);
            if (reader == null)
                return 0;

            reader.Read();
            horasDXC = OleDbUtiles.GetDoubleFromReader(reader, "PresupuestoDisponible");
            reader.Close();

            return horasDXC;

        }

        public static double GetPresupuestoEurosCliente(string proyecto)
        {
            double presupuesto = 0;
            string sql = "";

            sql = "";
            sql += "SELECT CosteCliente";
            sql += "  FROM Proyectos";
            sql += " WHERE Proyecto = '" + proyecto +"'";

            Globales.logger.WriteLog(sql);
            OleDbDataReader reader = UtilesDb.GetOleDbDataReader(Conexion.GetConexion(), sql);
            if (reader == null)
                return 0;

            reader.Read();
            presupuesto = OleDbUtiles.GetDoubleFromReader(reader, "CosteCliente");
            reader.Close();
            return presupuesto;

        }

        public static string GetNombreProyectoById(int id)
        {
            return UtilesDb.GetDatoPorId(Conexion.GetConexion(), "Proyectos", "Proyecto", (long)id);
        }

        public static string GetCodProyectoById(int id)
        {
            return UtilesDb.GetDatoPorId(Conexion.GetConexion(), "Proyectos", "CodProyecto", (long)id);
        }



        public static ProyectoDTO GetProyectoDTOById(int id)
        {
            //CalculosDAO.ActualizaProyecto(id);

            ProyectoDTO proyectoDto = new ProyectoDTO();
            string str = "" + " SELECT * " + "   FROM Proyectos" + "  WHERE Id = " + id.ToString("0");
            Globales.logger.WriteLog(str);
            OleDbDataReader oleDbDataReader = UtilesDb.GetOleDbDataReader(Conexion.GetConexion(), str);
            if (oleDbDataReader == null)
                return (ProyectoDTO)null;
            oleDbDataReader.Read();
            ProyectoDTO dto = ProyectosDAO.ReaderToDTO(oleDbDataReader);
            oleDbDataReader.Close();
            return dto;
        }


        public static ProyectoDTO GetProyectoDTOByNombreProyecto(string proyecto)
        {
            ProyectoDTO byNombreProyecto = new ProyectoDTO();
            if (!proyecto.Equals(""))
                return ProyectosDAO.GetProyectoDTOById(ProyectosDAO.GetIdProyectoByProyecto(proyecto));
            byNombreProyecto.Proyecto = "";
            return byNombreProyecto;
        }

        public static int GetIdProyectoByProyecto(string proyecto, int porDefecto=0)
        {
            string str = "" + " SELECT * " + "   FROM Proyectos";
            if (!proyecto.Equals(""))
                str = str + "  WHERE Proyecto = '" + proyecto + "'";
            Globales.logger.WriteLog(str);
            OleDbDataReader oleDbDataReader = UtilesDb.GetOleDbDataReader(Conexion.GetConexion(), str);
            if (oleDbDataReader == null)
                return -1;
            oleDbDataReader.Read();
            if (oleDbDataReader.HasRows)
            {
                porDefecto = oleDbDataReader.GetInt32(oleDbDataReader.GetOrdinal("Id"));
            }
            oleDbDataReader.Close();
            return porDefecto;
        }

        public static int GetIdProyectoByCodImputacion(string codigo, int porDefecto = 0)
        {
            string str = "" + " SELECT * " + "   FROM Proyectos";
            if (!codigo.Equals(""))
                str = str + "  WHERE CodImputacion = '" + codigo + "'";
            Globales.logger.WriteLog(str);
            OleDbDataReader oleDbDataReader = UtilesDb.GetOleDbDataReader(Conexion.GetConexion(), str);
            if (oleDbDataReader == null)
                return -1;
            oleDbDataReader.Read();
            if (oleDbDataReader.HasRows)
            {
                porDefecto = oleDbDataReader.GetInt32(oleDbDataReader.GetOrdinal("Id"));
            }
            oleDbDataReader.Close();
            return porDefecto;
        }

        public static bool GuardarRegistro(ProyectoDTO proyectoDto)
        {
            if (!ProyectosDAO.DepurarDTO(proyectoDto))
                return false;
            return proyectoDto == null || proyectoDto.Id == 0 || !UtilesDb.ExisteRegistroById("Proyectos", proyectoDto.Id, Conexion.GetConexion()) ? ProyectosDAO.InsertRegistro(proyectoDto) : ProyectosDAO.UpdateRegistro(proyectoDto);
        }


        public static bool Insert(OleDbConnection conn, ProyectoDTO proyectoDto)
        {
            MessageBox.Show("Revisar si este código es necesario");
            return false;

            string sql = "" + "INSERT INTO Proyectos (Proyecto, CodProyecto) " + " VALUES ('" + proyectoDto.Proyecto + "'," + "         '" + proyectoDto.CodProyecto + "')";
            return UtilesDb.EjecutaQuery(conn, sql, true);
        }

        public static bool Update(OleDbConnection conn, ProyectoDTO proyectoDto)
        {
            MessageBox.Show("Revisar si este código es necesario");
            return false;

            string sql = "" + "UPDATE Proyectos " + "   SET Proyecto = '" + proyectoDto.Proyecto + "'," + "       CodProyecto = '" + proyectoDto.CodProyecto + "'" + " WHERE Id = " + proyectoDto.Id.ToString();
            return UtilesDb.EjecutaQuery(conn, sql, true);
        }

        private static bool InsertRegistro(ProyectoDTO proyectoDto)
        {
            if (!ProyectosDAO.DepurarDTO(proyectoDto))
                return false;
            Conexion.GetConexion();

            string sql = "";

            //sql = "";
            //sql += "INSERT INTO Proyectos ";
            //sql += "         (Proyecto, CodProyecto, VPROV, HorasCliente, PresupuestoCliente, HorasEmpresa, FInicio, FFin, FCierre,";
            //sql += "          PresupuestoDisponible, Descripcion, TipoProyecto, EsProyecto) ";
            //sql += "  VALUES ('" + proyectoDto.Proyecto + "', ";
            //sql += "          '" + proyectoDto.CodProyecto + "', ";
            //sql += "          '" + proyectoDto.VProv + "', ";
            //sql += "           " + UtilesNumeros.DoubleFormatoUS2ESP(proyectoDto.HorasCliente.ToString()) + ", ";
            //sql += "           " + UtilesNumeros.DoubleFormatoUS2ESP(proyectoDto.PresupuestoCliente.ToString()) + ", ";
            //sql += "           " + UtilesNumeros.DoubleFormatoUS2ESP(proyectoDto.HorasEmpresa.ToString()) + ", ";
            //sql += "           " + UtilesAccessDb.GetFechaAccess(proyectoDto.FInicio) + ", ";
            //sql += "           " + UtilesAccessDb.GetFechaAccess(proyectoDto.FFin) + ", ";
            //sql += "           " + UtilesAccessDb.GetFechaAccess(proyectoDto.FCierre) + ", ";
            //sql += "           " + UtilesNumeros.DoubleFormatoUS2ESP(proyectoDto.PresupuestoDisponible.ToString()) + ", ";
            //sql += "          '" + proyectoDto.Descripcion + "', ";
            //sql += "          '" + proyectoDto.TipoProyecto + "', ";
            //sql += "          '" + proyectoDto.EsProyecto + "') ";

            try
            {
                UtilesDb.EjecutaQuery(Conexion.GetConexion(), sql, true);
                return true;
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
                return false;
            }
        }

        private static bool UpdateRegistro(ProyectoDTO proyectoDto)
        {

            string sql = "";
            Conexion.GetConexion();
            try
            {

                //sql  = "";
                //sql += "UPDATE Proyectos ";
                //sql += "   SET Proyecto = '" + proyectoDto.Proyecto + "', ";
                //sql += "       CodProyecto = '" + proyectoDto.CodProyecto + "', ";
                //sql += "       VPROV = '" + proyectoDto.VPROV + "', ";
                //sql += "       Descripcion = '" + proyectoDto.Descripcion + "', ";
                //sql += "       HorasCliente = " + UtilesNumeros.DoubleFormatoUS2ESP(proyectoDto.HorasCliente.ToString()) + ", ";
                //sql += "       PresupuestoCliente = " + UtilesNumeros.DoubleFormatoUS2ESP(proyectoDto.PresupuestoCliente.ToString()) + ", ";
                //sql += "       HorasEmpresa = " + UtilesNumeros.DoubleFormatoUS2ESP(proyectoDto.HorasEmpresa.ToString()) + ", ";
                //sql += "       PresupuestoDisponible = " + UtilesNumeros.DoubleFormatoUS2ESP(proyectoDto.PresupuestoDisponible.ToString()) + ", ";
                //sql += "       FInicio = " + UtilesAccessDb.GetFechaAccess(proyectoDto.FInicio) + ", ";
                //sql += "       FFin = " + UtilesAccessDb.GetFechaAccess(proyectoDto.FFin) + ", ";
                //sql += "       FCierre = " + UtilesAccessDb.GetFechaAccess(proyectoDto.FCierre) + ", ";
                //sql += "       TipoProyecto = '" + proyectoDto.TipoProyecto + "', ";
                //sql += "       EsProyecto = '" + proyectoDto.EsProyecto + "' ";
                //sql += "  WHERE Id = " + proyectoDto.Id.ToString("0");

                Globales.logger.WriteLog(sql);

                UtilesDb.EjecutaQuery(Conexion.GetConexion(), sql, true);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool UpdateRtf(int idBitacora, RichTextBox rtb)
        {
            string str = "" + "UPDATE Bitacora " + "    SET NotaRTF = @textoRtf" + "  WHERE Id = " + idBitacora.ToString("0");
            OleDbCommand oleDbCommand = new OleDbCommand(str, Conexion.GetConexion());
            oleDbCommand.Parameters.AddWithValue("@textoRtf", (object)rtb.Rtf);
            oleDbCommand.ExecuteNonQuery();
            Globales.logger.WriteLog(str);
            return true;
        }

        public static bool DeleteProyectoByDTO(ProyectoDTO dto) => ProyectosDAO.DeleteProyectoById(dto.Id);

        public static bool DeleteProyectoById(int id)
        {
            string str = "" + "DELETE FROM Proyectos" + " WHERE id = " + id.ToString("0");
            Globales.logger.WriteLog(str);
            return UtilesDb.EjecutaQuery(Conexion.GetConexion(), str);
        }

        private static bool DepurarDTO(ProyectoDTO dto)
        {
            try
            {
                //if (dto.FApertura == null || dto.FApertura == "")
                //    dto.FApertura = DateTime.Now.ToString("dd/MM/yyyy");
                //if (dto.FCierre == null || dto.FCierre == "")
                //    dto.FCierre = (string)null;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static ProyectoDTO ReaderToDTO(OleDbDataReader reader)
        {

            ProyectoDTO dto = new ProyectoDTO();

            dto.Id = OleDbUtiles.GetIntFromReader(reader, "Id");
            dto.Proyecto = OleDbUtiles.GetDatoAsString(reader, "Proyecto");
            dto.CodProyecto = OleDbUtiles.GetDatoAsString(reader, "CodProyecto");
            dto.VProv = OleDbUtiles.GetDatoAsString(reader, "VProv");
            dto.Descripcion = OleDbUtiles.GetDatoAsString(reader, "Descripcion");
            dto.IdEstado = OleDbUtiles.GetIntFromReader(reader, "IdEstado");

            return dto;

        }

    }
}

