using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    public class Program
    {
        private static sbyte[] genes = new sbyte[6];
        private const int populacao = 20;
        private const double taxaMutacao = 0.05;
        private const bool elitism = true;

        public static void Main(string[] args)
        {
            //Genética entre os indivíduos 
            //* Conforme figura 'b' do enunciado no moodle.
            Run(20, "111111");
        }
        
        //Regra de cruzamento
        private static Individuo Crossover(Individuo indiv1, Individuo indiv2)
        {
            Individuo novaGeracao = new Individuo();
            for (int i = 0; i < novaGeracao.ComprimentoPadraoGene; i++)
            {
                var random = new Random();
                if (random.NextDouble() <= taxaMutacao)
                {
                    novaGeracao.DefinirGeneUnico(i, indiv1.ObterGeneUnico(i));
                }
                else
                {
                    novaGeracao.DefinirGeneUnico(i, indiv2.ObterGeneUnico(i));
                }
            }
            return novaGeracao;
        }

        //Regra de mutação
        private static void Mutacao(Individuo indiv)
        {
            for (int i = 0; i < indiv.ComprimentoPadraoGene; i++)
            {
                var random = new Random();

                if (random.NextDouble() <= taxaMutacao)
                {
                    sbyte gene = (sbyte)(long)Math.Round(random.NextDouble(), MidpointRounding.AwayFromZero);
                    indiv.DefinirGeneUnico(i, gene);
                }
            }
        }

        //Regra de seleção
        private static Individuo Selecao(Populacao pop)
        {
            Populacao selecao = new Populacao(populacao, false);
            for (int i = 0; i < populacao; i++)
            {
                var random = new Random();

                int randomId = (int)(random.NextDouble() * pop.Individuals.Count);
                selecao.Individuals.Insert(i, pop.ObterIndividuo(randomId));
            }
            Individuo fittest = selecao.IndividuoApto;
            return fittest;
        }

        //Agora iremos fazer com que a população evolua, pegando os parâmetros de seleção e cruzamento
        private static Populacao EvoluirPopulacao(Populacao popula)
        {
            int elitismOffset;
            Populacao novaPopulacao = new Populacao(30, false);

            if (elitism)
            {
                for (int i = 0; i < 20; i++)
                {
                    novaPopulacao.Individuals.Insert(i, popula.IndividuoApto);
                    popula.Individuals.Remove(popula.IndividuoApto);
                }
                elitismOffset = 20;
            }

            for (int i = elitismOffset; i < 30; i++)
            {
                Individuo indiv1 = Selecao(novaPopulacao);
                Individuo indiv2 = Selecao(novaPopulacao);
                Individuo newIndiv = Crossover(indiv1, indiv2);
                novaPopulacao.Individuals.Insert(i, newIndiv);
            }

            for (int i = elitismOffset; i < novaPopulacao.Individuals.Count; i++)
            {
                Mutacao(novaPopulacao.ObterIndividuo(i));
            }

            return novaPopulacao;
        }

        public static int ObterFitness(Individuo individual)
        {
            int fitness = 0;
            for (int i = 0; i < individual.ComprimentoPadraoGene && i < genes.Length; i++)
            {
                if (individual.ObterGeneUnico(i) == genes[i])
                {
                    fitness++;
                }
            }
            return fitness;
        }

        private static string Solucao
        {
            set
            {
                genes = new sbyte[value.Length];
                for (int i = 0; i < value.Length; i++)
                {
                    string character = value.Substring(i, 1);
                    if (character.Contains("0") || character.Contains("1"))
                    {
                        genes[i] = sbyte.Parse(character);
                    }
                    else
                    {
                        genes[i] = 0;
                    }
                }
            }
        }

        private static int MaxFitness
        {
            get
            {
                return genes.Length;
            }
        }

        public static void Run(int tamanhoPopulacao, string solucao)
        {

            Solucao = solucao;
            Populacao populacaoMut = new Populacao(tamanhoPopulacao, true);

            int contagemGeracao = 1;

            while (populacaoMut.IndividuoApto.Apto < MaxFitness)
            {
                Console.WriteLine("Geração: " + contagemGeracao + "  Corrigir genes encontrados: " + populacaoMut.IndividuoApto.Apto);
                populacaoMut = EvoluirPopulacao(populacaoMut);
                contagemGeracao++;
            }
            Console.WriteLine("==========================================");
            Console.WriteLine("Achamos um bom!");
            Console.WriteLine("Geração: " + contagemGeracao);
            Console.WriteLine("Mutação: " + populacaoMut.IndividuoApto);
            Console.WriteLine("==========================================");
            Console.ReadKey();
        }
    }
}