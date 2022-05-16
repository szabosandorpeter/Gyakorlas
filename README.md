# Kereső:

- > Controllers/ArukController.cs 

```bash
// GET: Aruk
        public async Task<IActionResult> Index(string Megnevezes, string Beszallito)
        {
            var model = new AruKeres();
            var aruk = _context.Aru.Select(x => x);

            if(!string.IsNullOrEmpty(Megnevezes))
            {
                aruk = aruk.Where(x => x.Megnevezes.Contains(Megnevezes));
                model.Megnevezes = Megnevezes;
            }

            if(!string.IsNullOrEmpty(Beszallito))
            {

                aruk = aruk.Where(x => x.Beszallito.Equals(Beszallito));
                model.Beszallito = Beszallito;
            }

            model.AruLista = await aruk.OrderBy(x => x.Megnevezes).ToListAsync();
            model.BeszallitoLista = new SelectList(await _context.Aru.Select(x => x.Beszallito).Distinct().OrderBy(x => x).ToListAsync());
            
            return View(model);
        }
```
 - >  Views/Aruk/Index.cshtml

```bash
<h1>Termék kereső</h1>

<p>
    <a asp-action="Create" class="btn btn-info">Új létrehozása</a>
</p>

<form asp-controller="Aruk" asp-action="Index" method="get">
    Megnevezés:
    <input asp-for="Megnevezes">

   Beszállító:
    <select asp-for="Beszallito" asp-items="Model.BeszallitoLista">
        <option value="">Összes</option>
    </select>
    <input type="submit" value="Keresés" class="btn btn-success">
</form>

```

# Validátor
```bash
<script>
    $.validator.methods.number = function (value, element) {
        return this.optional(element) || /-?(?:\d+|\d{1,3}(?:[\s\.,]\d{3})+)(?:[\.,]\d+)?$/.test(value);
    }
</script>
```

# Kereső  csicsásan: 
```bash
<div class="container d-flex justify-content-center align-items-center mt-5 mb-5">
    <div class="row">
        <div class="col-lg">
            <div class="card shadow">
                <div class="card-body">
                    <h1>Termék keresés</h1>
                    <p>
                        <a asp-action="Create" class="btn btn-primary">Új létrehozása</a>
                    </p>
                    <form asp-action="Index" asp-controller="Raktar" method="get">
                        Megnevezés:
                        <input asp-for="Megnevezes" class="form-control" />

                        Beszállító:
                        <select asp-for="Beszallito" asp-items="Model.BeszallitoLista" class="form-control">
                            <option value="">Összes</option>
                        </select>
                        <button type="submit" class="btn btn-success mt-3">Keresés</button>
                    </form>
                </div>
            </div>
        </div>
    </div>
</div>
```
