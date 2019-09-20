using Loja.Business;
using Loja.Domain;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Loja.App.Web.Controllers
{
    public class ProdutosController : Controller
    {
        private IProdutoService _service;
        string[] _imageTypes;

        public ProdutosController()
        {
            _service = new ProdutoService();

            _imageTypes = new string[]{
                                "image/gif",
                                "image/jpeg",
                                "image/jpg",
                                "image/pjpeg",
                                "image/png"
                            };
        }

        public ActionResult Index()
        {
            var produtos = _service.All();
            return View(produtos);
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = _service.GetById(id.Value);
            if (produto == null)
            {
                return HttpNotFound();
            }

            LoadDropDownLists(produto);

            return View(produto);
        }

        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(_service.GetCategorias(), "Id", "Nome");
            ViewBag.FabricanteId = new SelectList(_service.GetFabricantes(), "Id", "Nome");
            ViewBag.UsuarioId = new SelectList(_service.GetUsuarios(), "Id", "Nome");

            var model = new ProdutoViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel produto)
        {
            if (produto.ImageUpload == null || produto.ImageUpload.ContentLength == 0)
            {
                ModelState.AddModelError("ImageUpload", "Este campo é obrigatório");
            }
            else if (!_imageTypes.Contains(produto.ImageUpload.ContentType))
            {
                ModelState.AddModelError("ImageUpload", "Escolha uma iamgem GIF, JPG ou PNG.");
            }

            if (ModelState.IsValid)
            {
                var novoProduto = new Produto();
                novoProduto.InjectFrom(produto);
                novoProduto.UsuarioId = 1;
                novoProduto.DataCadastro = DateTime.Now;
                // Salvar a imagem para a pasta e pega o caminho
                var imagemNome = String.Format("{0:yyyyMMdd-HHmmssfff}", DateTime.Now);
                var extensao = System.IO.Path.GetExtension(produto.ImageUpload.FileName).ToLower();
                using (var img = System.Drawing.Image.FromStream(produto.ImageUpload.InputStream))
                {
                    novoProduto.ImagemURL = String.Format("/Uploads/{0}{1}", imagemNome, extensao);
                    // Salva imagem 
                    SalvarImagem(img, novoProduto.ImagemURL);
                }

                _service.Save(novoProduto);

                TempData["success"] = true;
                return RedirectToAction("Index");
            }

            LoadDropDownLists(produto);

            TempData["error"] = true;
            return View(produto);
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = _service.GetById(id.Value);
            if (produto == null)
            {
                return HttpNotFound();
            }

            LoadDropDownLists(produto);

            var viewModel = new ProdutoViewModel();
            viewModel.InjectFrom(produto);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var produtoAlterar = _service.GetById(produto.Id.Value);
                produto.DataCadastro = produtoAlterar.DataCadastro;

                produtoAlterar.InjectFrom(produto);
                produtoAlterar.UsuarioId = 1;

                if (produto.ImageUpload != null)
                {
                    if (!_imageTypes.Contains(produto.ImageUpload.ContentType))
                    {
                        ModelState.AddModelError("ImageUpload", "Escolha uma iamgem GIF, JPG ou PNG.");
                    }

                    // Salvar a imagem para a pasta e pega o caminho
                    var imagemNome = String.Format("{0:yyyyMMdd-HHmmssfff}", DateTime.Now);
                    var extensao = System.IO.Path.GetExtension(produto.ImageUpload.FileName).ToLower();
                    using (var img = System.Drawing.Image.FromStream(produto.ImageUpload.InputStream))
                    {
                        produtoAlterar.ImagemURL = String.Format("/Uploads/{0}{1}", imagemNome, extensao);

                        // Salva imagem 
                        SalvarImagem(img, produtoAlterar.ImagemURL);
                    }
                }

                _service.Save(produtoAlterar);

                TempData["success"] = true;
                return RedirectToAction("Index");
            }

            LoadDropDownLists(produto);

            TempData["error"] = true;
            return View(produto);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = _service.GetById(id.Value);
            if (produto == null)
            {
                return HttpNotFound();
            }

            LoadDropDownLists(produto);
            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Produto produto = _service.GetById(id);
            _service.Remove(id);

            TempData["success"] = true;
            return RedirectToAction("Index");
        }

        public ActionResult Grafico()
        {
            var chartData = _service.GetPosicaoEstoqueChartData();
            ViewBag.chartLabels = string.Format("'{0}'", string.Join("','", chartData.Select(p => p.Fabricante)));
            ViewBag.chartValues = string.Format("'{0}'", string.Join("','", chartData.Select(p => p.Estoque)));

            return View(chartData);
        }

        private void SalvarImagem(Image img, string caminho)
        {
            using (System.Drawing.Image novaImagem = new Bitmap(img))
            {
                novaImagem.Save(Server.MapPath(caminho), img.RawFormat);
            }
        }
        private void LoadDropDownLists(Produto produto = null)
        {
            if (produto != null)
            {
                ViewBag.CategoriaId = new SelectList(_service.GetCategorias(), "Id", "Nome", produto.CategoriaId);
                ViewBag.FabricanteId = new SelectList(_service.GetFabricantes(), "Id", "Nome", produto.FabricanteId);
                ViewBag.UsuarioId = new SelectList(_service.GetUsuarios(), "Id", "Nome", produto.UsuarioId);

                return;
            }

            ViewBag.CategoriaId = new SelectList(_service.GetCategorias(), "Id", "Nome");
            ViewBag.FabricanteId = new SelectList(_service.GetFabricantes(), "Id", "Nome");
            ViewBag.UsuarioId = new SelectList(_service.GetUsuarios(), "Id", "Nome");
        }
        private void LoadDropDownLists(ProdutoViewModel produto = null)
        {
            if (produto != null)
            {
                ViewBag.CategoriaId = new SelectList(_service.GetCategorias(), "Id", "Nome", produto.CategoriaId);
                ViewBag.FabricanteId = new SelectList(_service.GetFabricantes(), "Id", "Nome", produto.FabricanteId);
                ViewBag.UsuarioId = new SelectList(_service.GetUsuarios(), "Id", "Nome", produto.UsuarioId);

                return;
            }

            ViewBag.CategoriaId = new SelectList(_service.GetCategorias(), "Id", "Nome");
            ViewBag.FabricanteId = new SelectList(_service.GetFabricantes(), "Id", "Nome");
            ViewBag.UsuarioId = new SelectList(_service.GetUsuarios(), "Id", "Nome");
        }
    }
}