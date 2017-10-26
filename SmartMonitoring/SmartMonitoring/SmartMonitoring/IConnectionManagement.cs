using SmartMonitoring.BBDD;
using SmartMonitoring.MVVM;
using SmartMonitoring.OBDII;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoring
{
    public interface IConnectionManagement
    {
        void ConsultParameters();

        ViewModel getViewModel();

        List<DiagnosticTroubleCode> DiagnosticCar();

        SQLiteConnection getSQLConnection();

        void InitializedOBD2();

        List<byte[]> getPids();


        bool getGuardarDatos();

        void setGuardarDatos(bool value);

        bool getEstadoConsultar();

        void setEstadoConsultar(bool value);

        Visibilidad getVisibilidad();

        void setVisibilidad(Visibilidad visibilidad);
    }
}
