using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    public class Individuo
    {
        private sbyte[] genes;
        private readonly bool instanceFieldsInitialized = false;
        private int comprimentoGenePadrao = 6;
        private int fitness = 0;

        private void InitializeInstanceFields()
        {
            genes = new sbyte[comprimentoGenePadrao];
        }

        protected internal virtual sbyte ObterGeneUnico(int index)
        {
            return genes[index];
        }

        protected internal virtual void DefinirGeneUnico(int index, sbyte value)
        {
            genes[index] = value;
            fitness = 0;
        }

        public override string ToString()
        {
            string geneString = "";
            for (int i = 0; i < genes.Length; i++)
            {
                geneString += ObterGeneUnico(i);
            }
            return geneString;
        }

        public Individuo()
        {
            if (!instanceFieldsInitialized)
            {
                InitializeInstanceFields();
                instanceFieldsInitialized = true;
            }
            var random = new Random();

            for (int i = 0; i < genes.Length; i++)
            {
                sbyte gene = (sbyte)(long)Math.Round(random.NextDouble(), MidpointRounding.AwayFromZero);
                genes[i] = gene;
            }
        }

        public virtual int ComprimentoPadraoGene
        {
            get
            {
                return comprimentoGenePadrao;
            }
            set
            {
                comprimentoGenePadrao = value;
            }
        }

        public virtual sbyte[] Genes
        {
            get
            {
                return genes;
            }
            set
            {
                genes = value;
            }
        }

        public virtual int Apto
        {
            set
            {
                fitness = value;
            }
            get
            {
                if (fitness == 0)
                {
                    fitness = Program.ObterFitness(this);
                }
                return fitness;
            }
        }
    }
}