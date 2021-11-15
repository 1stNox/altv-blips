using AltV.BlipSystem.Server.Behaviour.Services;
using AltV.Net;
using AltV.Net.Elements.Entities;
using MySqlConnector;
using Npgsql;
using System.Text.Json;

namespace AltV.BlipSystem.Server.Behaviour
{
    public class BlipService : IBlipService
    {
        #region Fields

        private List<Structure.Blip> Blips { get; set; }
        private bool Initialized { get; set; }

        #endregion

        #region Constructors

        public BlipService()
        {
            Initialized = false;
        }

        #endregion

        #region Methods

        public void Initialize()
        {
            try
            {
                using (var db = new BlipContext())
                {
                    Blips = new List<Structure.Blip>(db.Blips);
                }

                Initialized = true;
            }
            catch (MySqlException e)
            {
                Alt.Log($"{e}");
            }
            catch (PostgresException e)
            {
                Alt.Log($"{e}");
            }
        }

        public void SynchronizeBlips(IPlayer player)
        {
            if (!Initialized)
            {
                Initialize();
            }

            var count = Blips.Count;
            var mod = count % 10;
            var diff = count / 10;
            if (mod != 0)
            {
                for (var i = 0; i < diff; i++)
                {
                    player.Emit("Blips:Synchronize", JsonSerializer.Serialize(Blips.Skip(i * 10).Take(10)));
                }
                player.Emit("Blips:Synchronize", JsonSerializer.Serialize(Blips.TakeLast(mod)));
                return;
            }

            for (var i = 0; i < diff; i++)
            {
                player.Emit("Blips:Synchronize", JsonSerializer.Serialize(Blips.Skip(i * 10).Take(10)));
            }
        }

        #endregion
    }
}
