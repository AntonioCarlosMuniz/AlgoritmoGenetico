Trabalho dedicado a disciplina de Algoritmos Avançados.

Desenvolva o algoritmo genético solicitado abaixo:


Indivíduo: Vetor de 6 posições (genes) onde cada gene vale 0 ou 1.

Cálculo da aptidão: por indivíduo. A aptidão é o somatório dos valores dos genes.

Tamanho da população inicial: 20

Tamanho da população após cruzamento: 30

Tamanho da população após seleção: 20 – os mais aptos, sem critério de desempate

Função objetivo: Ao menos um indivíduo da população obter aptidão máxima (6).


Regra de cruzamento (crossover):

Selecione, aleatoriamente, um ponto de crossover que divida os indivíduos que serão cruzados em duas partes. 
A seguir, permute os dois indivíduos, criando dois novos indivíduos que contêm metade de cada um dos indivíduos originais.

Regra de mutação:

Dados os novos indivíduos formados, selecione-os aleatoriamente e até 50% dos novos indivíduos, para serem modificados. 
A probabilidade de mutação é de 0,5%. Se ocorrer mutação, até 3 genes do indivíduo podem sofrer mutação. 
A quantidade de genes e quais devem ser escolhidos aleatoriamente.

Regra de ordenação da população:

Mantenha a população, sempre ao fim do processo de cálculo de aptidão, ordenada, em um vetor. 
Use um método eficiente de ordenação que tenha no máximo O(n log n) de complexidade de pior caso.
