using Fire_Emblem_View;

namespace Fire_Emblem.Habilidades
{
    public class EjecucionAplicadorHabilidad
    {
        private readonly Personaje _jugador;
        private readonly Personaje _rival;
        private readonly View _view;

        public EjecucionAplicadorHabilidad(Personaje jugador, Personaje rival, View view)
        {
            _jugador = jugador;
            _rival = rival;
            _view = view;
        }

        public void AplicarTodo()
        {
            AplicarHabilidades(_jugador, _rival);
            AplicarHabilidades(_rival, _jugador);
            PrintAllAbilities();
            AplicarNeutralizadores(_jugador, _rival);
            AplicarNeutralizadores(_rival, _jugador);
            //CalcularNetosStats();
        }

        private void AplicarHabilidades(Personaje jugador, Personaje rival)
        {
            foreach (var habilidad in jugador.habilidades)
            {
                var aplicador = new AplicadorHabilidadBonus(habilidad, jugador, rival, _view);
                aplicador.ConstructorHabilidad();
            }
        }

        private void AplicarNeutralizadores(Personaje jugador, Personaje rival)
        {
            foreach (var habilidad in jugador.habilidades)
            {
                var aplicador = new AplicadorHabilidadMixta(habilidad, jugador, rival, _view);
                aplicador.ConstructorHabilidad();
            }
        }

        private void PrintAllAbilities()
        {
            PrintFollowUpAtk(_jugador);
            PrintFollowUpAtk(_rival);
            PrintPlayerAbilities(_jugador);
            PrintNeutralizations(_jugador);
            PrintPlayerAbilities(_rival);
            PrintNeutralizations(_rival);
        }

        private void PrintFollowUpAtk(Personaje player)
        {
            if (player.atk_follow != 0)
            {
                var sign = player.atk_follow > 0 ? "+" : "";
                _view.WriteLine($"{player.name} obtiene Atk{sign}{player.atk_follow} en su Follow-Up");
            }
        }

        private void PrintPlayerAbilities(Personaje player)
        {
            //Todo: mover tal vez esto a el personaje 
            var orderedBonuses = GetOrderedStats(player.bonus_stats);
            var orderedPenalties = GetOrderedStats(player.penalty_stats);

            foreach (var stat in orderedBonuses)
            {
                PrintAbility(player, stat, stat.Value > 0 ? "+" : "");
            }

            foreach (var stat in orderedPenalties)
            {
                PrintAbility(player, stat, "");
            }
        }

        private void PrintAbility(Personaje player, KeyValuePair<string, int> stat, string sign)
        {
            var message = (player.first_atack == 1 && stat.Key == "Atk" && player.habilidad_fa)
                ? $"{player.name} obtiene {stat.Key}{sign}{stat.Value} en su primer ataque"
                : $"{player.name} obtiene {stat.Key}{sign}{stat.Value}";

            _view.WriteLine(message);
        }

        private void PrintNeutralizations(Personaje player)
        {
            foreach (var bonus in player.bonus_neutralizados)
            {
                _view.WriteLine($"Los bonus de {bonus} de {player.name} fueron neutralizados");
            }

            foreach (var penalty in player.penalty_neutralizados)
            {
                _view.WriteLine($"Los penalty de {penalty} de {player.name} fueron neutralizados");
            }
        }

        // private void CalcularNetosStats()
        // {
        //     _jugador.CalcularNetosStats();
        //     _rival.CalcularNetosStats();
        // }

        private IEnumerable<KeyValuePair<string, int>> GetOrderedStats(Dictionary<string, int> stats)
        {
            string[] order = { "Atk", "Spd", "Def", "Res" };
            return order.Where(stats.ContainsKey).Select(key => new KeyValuePair<string, int>(key, stats[key]));
        }
    }
}