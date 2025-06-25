using Cuadernotas.Clases.Comunes;
using Cuadernotas.Clases.Db;
using System.Data.OleDb;
using UtilesCs.Clases.Utilidades.Db;

namespace Cuadernotas.Clases.DAO.Subgrupos
{
    public class SubgruposDAO
    {

        public static int GetIdSubgrupoByGrupoSubgrupo(string grupo, string subgrupo)
        {
            string sql;
            int id = -1;

            sql = "";
            sql += "SELECT sg.Id AS IdRetorno ";
            sql += "  FROM Grupos g, Subgrupos sg";
            sql += " WHERE g.Id = sg.IdGrupo ";
            sql += "   AND Grupo = '" + grupo + "'";
            sql += "   AND Subgrupo = '" + subgrupo + "'";

            Globales.logger.WriteLog(sql);
            OleDbDataReader reader = UtilesDb.GetOleDbDataReader(Conexion.GetConexion(), sql);
            if (reader == null)
                return id;

            while (reader.Read())
            {
                id = OleDbUtiles.GetIntFromReader(reader, "IdRetorno", 1);
            }
            reader.Close();

            return id;

        }



    }
}

