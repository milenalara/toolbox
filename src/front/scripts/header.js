const headerSection = document.querySelector("#header");

function loadHeader() {
  const header = `
  <div class="z-4 logo ms-5">
  <div class="menu">
    <div class="area-logo">
    <a class="a_formatacao" href="./index.html"><img class="logo" src="../images/logo-toolbox.png" width="200px"></a>
    </div>
    <div class="pesquisar">
    <form class="d-flex" role="search">
    <input class="form-control me-1" id="pesquisa" type="search" placeholder="Busque um item..." aria-label="Search">
    <button class="btn" type="submit" onclick="pesquisaItens(event)"><img src="../images/iconsearch.png" width="23px"></button>
  </form>
    </div>
    <nav >
      <ul class="nav-topo">
        <li>
          <a class="a_formatacao" href="./emprestimos.html">PEDIDOS</a>
        </li>
        <li>
          <a class="a_formatacao" href="./produtosAlugados.html">MEUS ANUNCIOS</a>          
        </li>
        <li>
        <a class="a_formatacao" href="./cadastrarItens.html">ANUNCIAR ITEM</a>
        </li>
        <li>
          <a class="a_formatacao" href="./login.html">SAIR</a>          
        </li>
      </ul>
    </nav>
  </div>
  </div>
  `

  headerSection.innerHTML = header;
}

loadHeader();