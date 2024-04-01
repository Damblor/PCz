const val xml_pojazdy = """<pojazdy>
    <samochod>
        <nazwa>
        Honda Civic
        </nazwa>
        <rodzajPaliwa>
        3
        </rodzajPaliwa>
    </samochod>
    <motorowka>
        <nazwa>
        Super motorowka
        </nazwa>
        <rodzajPaliwa>
        0
        </rodzajPaliwa>
    </motorowka>
    <samochod>
        <nazwa>
        Mercedes CLK
        </nazwa>
        <rodzajPaliwa>
        5
        </rodzajPaliwa>
    </samochod>
    <rower>
        <nazwa>
        Giant
        </nazwa>
    </rower>
    <hulajnoga>
        <nazwa>
        Najfajniejsza hulajnoga
        </nazwa>
    </hulajnoga>
</pojazdy>"""

interface ISpalinowy {
    var iloscPaliwa: Int

    fun zatankuj(ilosc: Int, rodzajPaliwa: Int): Boolean;

    fun odczytajRodzajPaliwa(): Int;
}

interface IRodzajPaliwa {
    val rodzajPaliwa: Int
}

interface IParkowalny {
    fun parkuj(garaz: Garaz): Boolean
    fun wyparkuj(garaz: Garaz): Boolean
}

class Garaz {
    var pojazd: Pojazd? = null

    fun czyWolny(): Boolean {
        return pojazd == null
    }

    override fun toString(): String {
        return "Garaz: $pojazd"
    }
}

class Wypozyczalnia(private val pojemnosc: Int) {
    val garaze = mutableListOf<Garaz>()

    init {
        for (i in 0..<pojemnosc) {
            garaze.add(Garaz())
        }
    }

    fun dodajPojezd(pojazd: IParkowalny): Boolean {
        for (garaz in garaze) {
            if (pojazd.parkuj(garaz)) {
                return true
            }
        }
        return false
    }

    fun usunPojazd(id: Int): Boolean {
        for (garaz in garaze) {
            if (garaz.pojazd != null && garaz.pojazd!!.id == id) {
                garaz.pojazd = null
                return true
            }
        }
        return false
    }
}

abstract class Pojazd(val nazwa: String) {
    companion object {
        private var counter = 0

        fun getID(): Int {
            return counter++
        }
    }

    val id: Int = getID()

    override fun toString(): String {
        return "Pojazd: $nazwa, $id"
    }
}

class Samochod(nazwa: String, override val rodzajPaliwa: Int) : Pojazd(nazwa), ISpalinowy, IRodzajPaliwa, IParkowalny {
    override var iloscPaliwa: Int = 0

    override fun zatankuj(ilosc: Int, rodzajPaliwa: Int): Boolean {
        if (this.rodzajPaliwa and rodzajPaliwa != 0) {
            this.iloscPaliwa += ilosc
            return true
        }
        return false
    }

    override fun odczytajRodzajPaliwa(): Int {
        return this.rodzajPaliwa
    }

    override fun parkuj(garaz: Garaz): Boolean {
        if (garaz.czyWolny()) {
            garaz.pojazd = this
            return true
        }
        return false
    }

    override fun wyparkuj(garaz: Garaz): Boolean {
        if (garaz.pojazd == this) {
            garaz.pojazd = null
            return true
        }
        return false
    }

    override fun toString(): String {
        return "Samochod: $nazwa, ID: $id, rodzaj paliwa: $rodzajPaliwa, ilosc paliwa: $iloscPaliwa"
    }
}

class Motorowka(nazwa: String, override val rodzajPaliwa: Int) : Pojazd(nazwa), ISpalinowy, IRodzajPaliwa {
    override var iloscPaliwa: Int = 0

    override fun zatankuj(ilosc: Int, rodzajPaliwa: Int): Boolean {
        if (this.rodzajPaliwa == rodzajPaliwa) {
            this.iloscPaliwa += ilosc
            return true
        }
        return false
    }

    override fun odczytajRodzajPaliwa(): Int {
        return this.rodzajPaliwa
    }

    override fun toString(): String {
        return "Motorowka: $nazwa, ID: $id, rodzaj paliwa: $rodzajPaliwa, ilosc paliwa: $iloscPaliwa"
    }
}

class Rower(nazwa: String) : Pojazd(nazwa), IParkowalny {
    override fun parkuj(garaz: Garaz): Boolean {
        if (garaz.czyWolny()) {
            garaz.pojazd = this
            return true
        }
        return false
    }

    override fun wyparkuj(garaz: Garaz): Boolean {
        if (garaz.pojazd == this) {
            garaz.pojazd = null
            return true
        }
        return false
    }

    override fun toString(): String {
        return "Rower: $nazwa, ID: $id"
    }
}

class Hulajnoga(nazwa: String) : Pojazd(nazwa) {
    override fun toString(): String {
        return "Hulajnoga: $nazwa, ID: $id"
    }
}


fun main() {
    val pojazdy = xml_pojazdy.split('\n').map{it.trim()}

    val listaPojazdow = mutableListOf<Pojazd>()
    var i = 0
    while (i < pojazdy.size) {
        if (pojazdy[i] == "<samochod>") {
            val nazwa: String = pojazdy[i + 2]
            val rodzajPaliwa = pojazdy[i + 5].toInt()
            listaPojazdow.add(Samochod(nazwa, rodzajPaliwa))
            i += 7
        } else if (pojazdy[i] == "<motorowka>") {
            val nazwa = pojazdy[i + 2]
            val rodzajPaliwa = pojazdy[i + 5].toInt()
            listaPojazdow.add(Motorowka(nazwa, rodzajPaliwa))
            i += 7
        } else if (pojazdy[i] == "<rower>") {
            val nazwa = pojazdy[i + 2]
            listaPojazdow.add(Rower(nazwa))
            i += 4
        } else if (pojazdy[i] == "<hulajnoga>") {
            val nazwa = pojazdy[i + 2]
            listaPojazdow.add(Hulajnoga(nazwa))
            i += 4
        } else {
            i++
        }
    }

    for (pojazd in listaPojazdow) {
        println(pojazd)
    }

    val wypozyczalnia = Wypozyczalnia(5)

    println()
    println("Dodawanie pojazdow do wypozyczalni:")
    for (pojazd in listaPojazdow) {
        if (pojazd is IParkowalny) {
            print("$pojazd Zaparkowano: ")
            println(wypozyczalnia.dodajPojezd(pojazd))
        }
    }

    println()
    println("Wypisznie garazy:")
    for (garaz in wypozyczalnia.garaze) {
        println(garaz)
    }

    println()
    println("Usunieto pojazd: " + wypozyczalnia.usunPojazd(2))

    println()
    println("Wypisznie garazy:")
    for (garaz in wypozyczalnia.garaze) {
        println(garaz)
    }

    println()
    println("Tankowanie paliwa 0")
    for (pojazd in listaPojazdow) {
        if (pojazd is ISpalinowy) {
            print("$pojazd Zatankowano: ")
            println(pojazd.zatankuj(10, 0))
        }
    }

    println()
    println("Tankowanie paliwa 2")
    for (pojazd in listaPojazdow) {
        if (pojazd is ISpalinowy) {
            print("$pojazd Zatankowano: ")
            println(pojazd.zatankuj(14, 2))
        }
    }

    val listaPojazdowSorted = listaPojazdow.sortedWith(
        compareBy<Pojazd> { it is IParkowalny }
            .thenBy { it.javaClass.name }
            .thenBy { it.nazwa }
            .thenBy { if (it is ISpalinowy) it.odczytajRodzajPaliwa() else -1 }
            .thenBy { if (it is ISpalinowy) it.iloscPaliwa else 0 }
    )

    println()
    println("Sortowanie pojazdow po parkowalnosci, typie, nazwie, rodzaju paliwa i ilosci paliwa")
    for (pojazd in listaPojazdowSorted) {
        println(pojazd)
    }
}