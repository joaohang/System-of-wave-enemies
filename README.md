# System-of-wave-enemies
Sistema simples de criação de ondas de inimigos, colocando o script WaveManager em um objeto da sua cena basta você configurar as ondas como você deseja, veja abaixo o que você pode configurar.

**Opções de configuração das ondas de inimigos:**

*Tipos de onda*
 - Ondas que criam os inimigos em posições randômicas dentro de um range especificado por você.
 - Ondas que criam os inimigos randomicamente nas casas que você configurou(Explicarei o que são casas abaixo)
 - Ondas que criam os inimigos de acordo com a sequência de casas que você configurou.

*Configurações de ondas*
 - Quantidade de ondas
 - Tempo de spawn para cada onda
 - Quantidade de inimigos por onda
 - Ordem dos inimigos(Qual o inimigo que irá aparecer 1º, 2º e assim até terminar a quantidade de inimigos que você quer instanciar, os inimigos são definidos por um número que é a posição no array de inimigos)

*Configurações das casas*
 - Quantidade de casas
 
  As casas podem ser objetos vazios ou não da sua cena, as casas nada mais são do que uma posição(Transform).

*Configurações de inimigos*

  Na configurações de inimigos você deve colocar os objetos que iram ser criados de acordo com suas ondas. Lembre a posição do inimigo no array é o número que você usa para instanciar um inimigo de acordo com sua onda.

*Outras configurações*
 - Texto que mostra o número da onda atual
 - Sound effect ativado quando a uma troca de onda.

**No projeto você tem 2 cenas de exemplos e algumas sprites, você pode utilizar este projeto como desejar.**
