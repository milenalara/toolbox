var menuItem = document.querySelector("#menuItens");


function loadMenu() {
  const menu = `
  <div class="z-3"> 
    <div class="btn-expandir">
      <i class="bi bi-list"></i>
    </div>
    <ul>
      <li class="item-menu">
        <a href="./index.html">
          <span class="icon"><i class="bi bi-house"></i></span>
          <span class="txt-link">Home</span>
        </a>
      </li>
      <li class="item-menu">
        <a href="./cadastrarItens.html">
          <span class="icon"><i class="bi bi-bag-plus"></i></span>
          <span class="txt-link">Anunciar</span>
        </a>
      </li>
      <li class="item-menu">
      <a href="./produtosAlugados.html">
        <span class="icon"><i class="bi bi-megaphone"></i></span>
        <span class="txt-link">Produtos emprestados</span>
      </a>
    </li>
      <li class="item-menu">
        <a href="./emprestimos.html">
          <span class="icon"><i class="bi bi-basket2-fill"></i></span>
          <span class="txt-link">Meus Empréstimos</span>
        </a>
      </li>
      <li class="item-menu">
        <a href="./minhaconta.html">
          <span class="icon"><i class="bi bi-people-fill"></i></i></span>
          <span class="txt-link">Conta</span>
        </a>
      </li>
      <li class="item-menu">
        <a href="./sobrenos.html">
          <span class="icon"><i class="bi bi-info-circle-fill"></i></span>
          <span class="txt-link">Saiba mais sobre nós</span>
        </a>
      </li>
    </ul>
  </div>
  `

  menuItem.innerHTML = menu;
}

loadMenu();