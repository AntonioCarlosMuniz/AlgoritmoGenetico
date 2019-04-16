using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{    
    public class Populacao
    {
        private IList<Individuo> individuals;

        public Populacao(int size, bool createNew)
        {
            individuals = new List<Individuo>();
            if (createNew)
            {
                CriarNovaPopulacao(size);
            }
        }

        private void CriarNovaPopulacao(int size)
        {
            for (int i = 0; i < size; i++)
            {
                Individuo novoIndividuo = new Individuo();
                individuals.Insert(i, novoIndividuo);
            }
        }

        public virtual IList<Individuo> Individuals
        {
            get
            {
                return individuals;
            }
            set
            {
                individuals = value;
            }
        }

        public virtual Individuo ObterIndividuo(int index)
        {
            return individuals[index];
        }

        public virtual Individuo IndividuoApto
        {
            get
            {
                Individuo indApto = individuals[0];
                for (int i = 0; i < individuals.Count; i++)
                {
                    if (indApto.Apto <= ObterIndividuo(i).Apto)
                    {
                        indApto = ObterIndividuo(i);
                    }
                }
                return indApto;
            }
        }
    }
}