using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Repo
    {
        RestClient client = new RestClient("http://worldcup.sfg.io/");
        public List<Country> GetCountries()
        {
            List<Country> listaDrzava = new List<Country>();
            RestRequest request = new RestRequest("teams", Method.GET);
            string content = client.Execute(request).Content;
            listaDrzava = Country.FromJson(content);
            return listaDrzava;

        }

        public List<Match> GetMatches()
        {
            List<Match> listaMeceva = new List<Match>();
            RestRequest request = new RestRequest("matches", Method.GET);
            string content = client.Execute(request).Content;
            listaMeceva = Match.FromJson(content);
            return listaMeceva;
        }
        public List<Match> GetMatchesByFifaCode(string fifaId)
        {
            List<Match> listaMeceva = new List<Match>();
            List<Match> listaSvihMeceva = GetMatches();
            foreach (Match m in listaSvihMeceva)
            {
                if (m.HomeTeam.Code == fifaId || m.AwayTeam.Code == fifaId)
                {
                    listaMeceva.Add(m);
                }
            }
            return listaMeceva;
        }
        public List<StartingEleven> getStartingElevens(string fifaCode)
        {
            List<StartingEleven> listaStartingEleven = new List<StartingEleven>();
            List<Match> listaMeceva = GetMatchesByFifaCode(fifaCode);
            Match m = listaMeceva[0];
            if (m.HomeTeam.Code == fifaCode)
            {
                foreach (StartingEleven se in m.HomeTeamStatistics.StartingEleven)
                {
                    listaStartingEleven.Add(se);
                }
                foreach (StartingEleven se in m.HomeTeamStatistics.Substitutes)
                {
                    listaStartingEleven.Add(se);
                }
            }
            else
            {
                foreach (StartingEleven se in m.AwayTeamStatistics.StartingEleven)
                {
                    listaStartingEleven.Add(se);
                }
                foreach (StartingEleven se in m.AwayTeamStatistics.Substitutes)
                {
                    listaStartingEleven.Add(se);
                }
            }
            return listaStartingEleven;
        }


        public List<StartingEleven> getRankListPlayers(string fifaCode)
        {
            List<Match> listaMeceva = GetMatchesByFifaCode(fifaCode);
            List<StartingEleven> listaIgraca = getStartingElevens(fifaCode);
            foreach (Match m in listaMeceva)
            {
                if (m.HomeTeam.Code == fifaCode)
                {
                    foreach (TeamEvent tev in m.HomeTeamEvents)
                    {
                        if (tev.TypeOfEvent == TypeOfEvent.Goal)
                        {
                            foreach (StartingEleven sev in listaIgraca)
                            {
                                if (sev.Name == tev.Player)
                                {
                                    sev.Goals++;
                                }
                            }
                        }
                        if (tev.TypeOfEvent == TypeOfEvent.YellowCard)
                        {
                            foreach (StartingEleven sev in listaIgraca)
                            {
                                if (sev.Name == tev.Player)
                                {
                                    sev.YellowCards++;
                                }
                            }
                        }
                    }
                }

                else
                {
                    foreach (TeamEvent tev in m.AwayTeamEvents)
                    {
                        if (tev.TypeOfEvent == TypeOfEvent.Goal)
                        {
                            foreach (StartingEleven sev in listaIgraca)
                            {
                                if (sev.Name == tev.Player)
                                {
                                    sev.Goals++;
                                }
                            }
                        }
                        if (tev.TypeOfEvent == TypeOfEvent.YellowCard)
                        {
                            foreach (StartingEleven sev in listaIgraca)
                            {
                                if (sev.Name == tev.Player)
                                {
                                    sev.YellowCards++;
                                }
                            }
                        }
                    }
                }
            }
            return listaIgraca;
        }

    }
   
}
