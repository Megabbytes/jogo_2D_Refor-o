# jogo_2D_Refor-o
Jogo 2D criado para treinar a programação durante as aulas de reforço do tio Vini/ Leonardo Dicaprio


08/10 - pesquisa sobre SceneManager
# Pesquisa Resumida — SceneManagement na Unity

## 1. O que é SceneManagement?

O SceneManagement é um sistema da Unity responsável por gerenciar as cenas de um jogo. Ele permite carregar, reiniciar, trocar e descarregar cenas, facilitando a organização de fases, menus e ambientes.

## 2. Para que serve?

É utilizado para controlar a passagem entre fases, reiniciar o jogo, retornar ao menu principal e carregar diferentes cenários. Pode ser utilizado tanto em jogos 2D quanto em 3D.

## 3. Principais métodos

- LoadScene(): carrega uma cena.
- LoadSceneAsync(): carrega cenas de forma assíncrona, reduzindo interrupções.
- GetActiveScene(): identifica a cena ativa.
- UnloadSceneAsync(): descarrega uma cena.
- SetActiveScene(): define a cena ativa.
- CreateScene(): cria uma nova cena.
- MergeScenes(): une duas cenas.
- MoveGameObjectToScene(): transfere objetos entre cenas.

## 4. Modos de carregamento

Single: carrega uma cena e substitui as anteriores.

Additive: permite carregar várias cenas simultaneamente, sem remover automaticamente as anteriores.

## 5. Propriedades e eventos

O SceneManagement possui propriedades como `sceneCount`, que informa a quantidade de cenas na lista interna, e `sceneCountInBuildSettings`, que indica quantas cenas estão configuradas na compilação.

Também possui eventos como `sceneLoaded`, `sceneUnloaded` e `activeSceneChanged`, que identificam mudanças no carregamento e na ativação das cenas.

## 6. Recursos avançados

O sistema oferece recursos como `LoadSceneParameters`, utilizado para configurar o carregamento, e `LocalPhysicsMode`, que permite trabalhar com ambientes físicos independentes.

Também existe o `EditorSceneManager`, utilizado para criar, abrir, salvar e organizar cenas dentro do editor da Unity.

## 7. Vantagens e desvantagens

Vantagens: facilita a organização do jogo, automatiza transições, permite reiniciar fases e gerenciar múltiplos cenários.

Desvantagens: cenas muito pesadas podem causar travamentos, e o gerenciamento inadequado pode aumentar o consumo de memória.

## 8. Conclusão

O SceneManagement é fundamental no desenvolvimento de jogos na Unity, pois permite controlar diferentes cenas de maneira organizada e eficiente. Seus recursos facilitam a criação de menus, fases e transições, contribuindo para o desenvolvimento de jogos 2D e 3D mais estruturados.

Fonte: Documentação oficial da Unity — SceneManager
