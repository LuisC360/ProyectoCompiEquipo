using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace Compiladores
{
    class Algoritmos
    {
        //Lista de reglas que se utilizaran
        List<Separa> lregl;
        //Este es un objeto contenedor de tokens
        CTK contks;
        //Variable que representa el simbolo inicial
        NT inicial;
        //Variable que representa la expresion regular
        Separa expreg;
        //Este es el textbox donde esta la gramatica.
        RichTextBox textgram;
        //Bandera que nos dice si es tipo LR(1)
        public bool tlr1;
        //Variable para identificar errores
        public string errorCelda;


        public Stack<string> Esquema;//////////////////////// 
        public int ReduTemp;
        public List<string> Temporal;
        string acciontrad;

        //Constructor donde se inicializan las variables
        public Algoritmos(RichTextBox txtbx)
        {
            lregl = new List<Separa>();
            contks = new CTK();
            inicial = null;
            expreg = new Separa();
            expreg.ladoIzq = new NT("E.R.");
            textgram = txtbx;
            tlr1 = false;
            Esquema = new Stack<string>();///////////////////
            ReduTemp = 0;
            Temporal = new List<string>();
            acciontrad = "";
        }

        //Metodo que busca los simbolos iniciales.
        public void sinicial()
        {
            bool inic;
            inicial = null;

            for(int g=0; g<lregl.Count(); g++)
            {
                inic = true;
                for (int x = 0; x < lregl.Count; x++)
                {
                    if (x != g)
                    {
                        foreach (Produccion p in lregl[x].derecha)
                        {
                            foreach (NT tk in p.ltok)
                            {
                                if (tk == lregl[g].ladoIzq)
                                {
                                    inic = false;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (inic == true)
                {
                    inicial = lregl[g].ladoIzq;
                    break;
                }
            }
            if (inicial == null)
                inicial = lregl[0].ladoIzq;
        }

        //Metodo para obtener los primeros de los NT primero y depues de los Term.
        public void Primeros()
        {
            bool b = false;
            bool b2 = false;
            List<NT> lNT = contks.noterm();

            for(int x=0; x< lNT.Count(); x++)
            {
                for(int y=0; y<lNT[x].listaP.Count(); y++)
                {
                    if (lNT[x].listaP[y].ltok[0].esTerminal == true)
                    {
                        b = lNT[x].primero.agregatkprim(lNT[x].listaP[y].ltok[0]);
                    }
                }
            }
            int n;
            do
            {
                b2 = false;
                for(int e=0; e<lNT.Count; e++)
                {
                    /////////////////////////Thread.Sleep(40);
                    for(int w=0; w<lNT[e].listaP.Count; w++)
                    {
                        n = 0;
                        for(int v=0; v<lNT[e].listaP[w].ltok.Count(); v++)
                        {
                            if (lNT[e].listaP[w].ltok[v].esTerminal == false)
                            {
                                b = lNT[e].primero.agconjunto(lNT[e].listaP[w].ltok[v].primero.ltok);
                                if (b == true)
                                    b2 = true;
                                if (lNT[e].listaP[w].ltok[v].primero.seps() == false)
                                    break;                                
                                else
                                {
                                    if ((n + 1) == lNT[e].listaP[w].ltok.Count)
                                    {
                                        
                                        b = lNT[e].primero.agregatkprim(new NT("ε"));
                                        if (b == true)
                                            b2 = true;
                                    }
                                }
                            }
                            else
                            {
                                lNT[e].primero.agregatkprim(lNT[e].listaP[w].ltok[v]);
                                break;
                            }
                            n++;
                        }
                    }
                }
            } while (b2 == true);
        }

        //Metodo para obtener los siguientes.
        public void Siguientes()
        {
            bool b = false;
            bool b2 = false;
            NT tk = new NT("$");
            tk.op("$");
            contks.agregaToken(tk);

            sinicial();

            if (inicial != null)
            {
                inicial.siguiente.agregatkprim(tk);
                do
                {
                    b2 = false;
                    foreach (Separa r in lregl)
                    {
                        foreach (Produccion pro in r.derecha)
                        {
                            for (int x = 0; x < pro.ltok.Count; x++)
                            {
                                tk = pro.ltok[x];
                                if (tk.esTerminal == false)
                                {
                                    if ((x + 1) < pro.ltok.Count)
                                    {
                                        for (int k = (x + 1); k < pro.ltok.Count; k++)
                                        {
                                            if (pro.ltok[k].esTerminal == true)
                                            {
                                                b = tk.siguiente.agregatkprim(pro.ltok[k]);
                                                if (b == true) b2 = true;
                                                break;
                                            }
                                            else
                                            {
                                                b = tk.siguiente.agconjunto(pro.ltok[k].primero.ltok);
                                                if (b == true) b2 = true;
                                                if (pro.ltok[k].primero.seps() == false) break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        b = tk.siguiente.agconjunto(r.ladoIzq.siguiente.ltok);
                                        if (b == true) b2 = true;
                                    }
                                }
                            }
                        }
                    }

                } while (b2 == true);
            }
            else
                MessageBox.Show("No hay simbolo inicial");
        }

        //Se crea la lista de reglas.
        public bool creglas()
        {
            string r;
            int act = 0;
            bool res = false;
            int prodact = 1;

            lregl.Clear();
            contks.Clear();

            for (int aux = 0; aux < textgram.Lines.Count(); aux++)
            {
                r = textgram.Lines[aux];
                textgram.SelectionStart = act;

                if ((r.Length > 0))
                {
                    if (verifica(r, ref prodact) == true)
                    {
                        res = true;
                        textgram.Select(act, r.Length);
                        textgram.SelectionColor = Color.Black;
                        textgram.SelectionBackColor = Color.White;
                    }
                    else
                    {
                        MessageBox.Show("Existen errores en la gramatica");
                        textgram.Select(act, r.Length);
                        textgram.SelectionColor = Color.Green;
                        textgram.SelectionBackColor = Color.Black;
                    }
                }
                act = act + r.Length + 1;
            }
            foreach (var t in contks.lista)
            {

                if (lregl.Find(x => x.ladoIzq.nom == t.nom) == null)
                {
                    t.esTerminal = true;
                }
            }
            return res;
        }

        //Metodo para aumentar la gramatica.
        public void gramaum()
        {
            Separa aumentada = new Separa();
            aumentada.ladoIzq = new NT(inicial.nom + "'");
            aumentada.ladoIzq.NoTerminal();
            contks.agregaToken(aumentada.ladoIzq);
            Produccion prod = new Produccion();
            prod.agregarprim(inicial);
            aumentada.derecha.Add(prod);
            aumentada.ladoIzq.listaP = aumentada.derecha;
            lregl.Insert(0, aumentada);
        }

        //Esta funcion hace un split cuando encuatra la flecha y verifica que se divida en dos
        //y que en ninguno de los dos lados existan errores.
        public bool verifica(string ren, ref int act)
        {
            string cad = ren.Replace("->", "→");
            string[] datos = cad.Split('→');

            if (datos.Count() == 2)
            {
                if (evaluavalidez(datos[0], datos[1], ref act) == true)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        //Se evaluan 2 cadenas para verificar que tengan tokens validos.
        public bool evaluavalidez(string izq, string der, ref int act)
        {
            Separa nuev = new Separa();
            Separa verex;
            nuev.partiz(izq.Replace(" ", ""), contks);
            verex = buscar(nuev);
            if (verex != null)
                nuev = verex;
            if (nuev.parder(der, contks, ref act) == false)
            {
                nuev.ladoIzq.Terminal();
                return false;
            }
            if (verex == null)
            {
                lregl.Add(nuev);
                nuev.ladoIzq.listaP = nuev.derecha;
            }
            return true;
        }

        //Se busca si hay una regla ingual a la que se le pasa 
        public Separa buscar(Separa aux)
        {
            return lregl.Find((Predicate<Separa>)delegate (Separa regla)
            {
                return aux.ladoIzq.nom == regla.ladoIzq.nom;
            });
        }

        //Metodo que crea las filas de la tabla de AS.
        public void filastabla(DataGridView tabla, CEdos conestados, List<NT> lterm, List<NT> lnt)
        {
            string vcel;
            string[] data;

            data = new string[tabla.ColumnCount];

            foreach (AFD estado in conestados.estados)
            {
                for (int i = 0; i < tabla.ColumnCount; i++)
                    data[i] = "";
                data[0] = estado.num.ToString();

                foreach (Infoenla en in estado.listaEnlaces)
                {
                    vcel = data[en.token.nCol];
                    if (vcel != "")
                    {
                        if (errorCelda == "")
                        {
                            if (vcel[0] == 'S') errorCelda = "Desplazar/";
                            else errorCelda = "Reducir/";
                            errorCelda += "Desplazar a " + estado.num.ToString();
                        }
                        tlr1 = false;
                    }
                    if (en.token.esTerminal == true)
                        data[en.token.nCol] = data[en.token.nCol] + "Desplazar a " + en.estAFD.num.ToString();
                    else
                        data[en.token.nCol] = data[en.token.nCol] + en.estAFD.num.ToString();
                }
                foreach (Separa reg in estado.lreg)
                {
                    if (reg.derecha[0].ult().oper == ".")
                    {
                        foreach (NT tk in reg.tksbusqueda.ltok)
                        {
                            vcel = data[tk.nCol];
                            if (vcel != "")
                            {
                                if (errorCelda == "")
                                {
                                    if (vcel[0] == 'S') errorCelda = "Desplazar/";
                                    else errorCelda = "Reducir/";
                                    errorCelda += "Reducir en " + estado.num.ToString();
                                }
                                tlr1 = false;
                            }
                            if (reg.derecha[0].numero == 0)
                                data[tk.nCol] = data[tk.nCol] + "Aceptar";
                            else
                                data[tk.nCol] = data[tk.nCol] + "Reducir " /*+ reg.mostrarr()*/ + reg.derecha[0].numero.ToString();
                        }
                    }
                }
                tabla.Rows.Add(data);
            }
        }

        //Metodo que crea el AFD.
        public AFD creacionafd(CEdos cjedos)
        {
            List<Separa> laux = new List<Separa>();
            Separa inic = lregl[0].coprod();
            inic.derecha[0].ponerpunto();
            inic.tksbusqueda.agregarprim(contks.buscar("$"));
            laux.Add(inic);
            AFD ini = new AFD(laux, cjedos);
            cjedos.agregaEstado(ini);
            ini.eval();
            return ini;
        }

        //Metodo para mostrar el treeview.
        public void motrafd(CEdos cjedos, TreeView arbol)
        {
            TreeNode rz;
            TreeNode nd;
            arbol.Nodes.Clear();
            foreach (AFD estado in cjedos.estados)
            {
                rz = new TreeNode(estado.num.ToString());
                arbol.Nodes.Add(rz);
                foreach (Separa regla in estado.lreg)
                {
                    nd = new TreeNode(regla.muestraprod());
                    rz.Nodes.Add(nd);
                }
                foreach (Infoenla en in estado.listaEnlaces)
                {
                    nd = new TreeNode(en.muestraEnlace());
                    rz.Nodes.Add(nd);
                }
                rz.ExpandAll();
            }
        }

        //Metodo principal para obtener el AFD y la tabla de Analisis.
        public void lr1princ(TreeView arbol, DataGridView tabla)
        {
            CEdos cjedos = new CEdos();
            AFD grf;
            tlr1 = true;
            errorCelda = "";
            sinicial();
            if (inicial != null)
            {
                gramaum();
                sinicial();
                Primeros();
                Siguientes();
                grf = creacionafd(cjedos);
                motrafd(cjedos, arbol);
                tablas(tabla, cjedos);
            }
            else
                MessageBox.Show("No hay simbolo inicial");
        }

        //Metodo para crear la tabla de AS.
        public void tablas(DataGridView tabla, CEdos cjedos)
        {
            int contColumnas = 1;
            tabla.Columns.Clear();
            List<NT> lt = contks.buscaterminales();
            List<NT> lnt = contks.noterm();
            DataGridViewCell ren = new DataGridViewTextBoxCell();
            DataGridViewColumn col = new DataGridViewColumn();
            col.Name = "Estado";
            col.CellTemplate = ren;
            tabla.Columns.Add(col);
            foreach (NT tk in lt)
            {
                if (tk.nom != "ε")
                {
                    col = new DataGridViewColumn();
                    col.Name = tk.nom;
                    col.CellTemplate = ren;
                    tabla.Columns.Add(col);
                    tk.nCol = contColumnas;
                    contColumnas++;
                }
            }
            int n = 1;
            foreach (NT tk in lnt)
            {
                if (n < lnt.Count)
                {
                    col = new DataGridViewColumn();
                    col.Name = tk.nom;
                    col.CellTemplate = ren;
                    tabla.Columns.Add(col);
                    tk.nCol = contColumnas;
                    contColumnas++;
                }
                n++;
            }
            filastabla(tabla, cjedos, lt, lnt);
        }

        //Metodo para reducir la pila
        public bool reducir(Separa rg, Produccion pila, DataGridView tablan)
        {
            //Temporal.Clear();
            string cad;
            if (rg.derecha[0].ltok[0].nom == "ε")
            {
                cad = buscacel(tablan, int.Parse(pila.ult().nom), rg.ladoIzq.nCol);
                pila.nuevo(rg.ladoIzq);
                pila.nuevo(new NT(cad));
            }
            else
            {
                for (int i = rg.derecha[0].ltok.Count - 1; i >= 0; i--)
                {
                    pila.removult();
                    if (pila.ult().nom == rg.derecha[0].ltok[i].nom)
                    {
                        if (pila.ult().valex != null)
                        {
                            Acciones(ReduTemp, pila.ult().valex);
                        }
                        pila.removult();
                    }
                    else
                        return false;
                }
            }
            return true;
        }

        //Metodo que busca una celda en especifico en la tabla de AS.
        public string buscacel(DataGridView tabs, int row, int col)
        {
            string valor;
            if (tabs[col, row].Value == null)
                valor = "";
            else
                valor = tabs[col, row].Value.ToString();
            return valor;
        }

        //Metodo para verificar que una cadena sea valida y regresa la respuesta si es o no valida
        public bool evaluar(RichTextBox bloc2, DataGridView tabla, DataGridView tablaAS)
        {
            int row;
            string linea;
            Produccion pila = new Produccion();
            Produccion cadena = new Produccion();
            string cadPila = "";
            string cadCad = "";
            string accion = "";
            List<Separa> listaR = new List<Separa>();
            tabla.Rows.Clear();
            Esquema.Clear();

            if (lregl.Count == 0)
            {
                MessageBox.Show("No es LR1");
                return false;
            }

            Separa nuevaR;
            foreach (Separa r in lregl)
            {
                foreach (Produccion prod in r.derecha)
                {
                    nuevaR = new Separa();
                    nuevaR.ladoIzq = r.ladoIzq;
                    nuevaR.derecha.Add(prod);
                    listaR.Add(nuevaR);
                }
            }

            pila.agregatkprim(contks.buscar("$"));
            pila.agregatkprim(new NT("0"));

            for (int fila = 0; fila < bloc2.Lines.Count(); fila++)
            {
                linea = bloc2.Lines[fila];
                if (linea.Length > 0)
                {
                    linea = linea + " \0";
                    if (cadena.creaCadena(linea, contks) == false)
                        return false;
                }
            }

            cadena.agregatkprim(contks.buscar("$"));

            while (accion != "Aceptar")
            {
                acciontrad = "";
                accion = buscacel(tablaAS, int.Parse(pila.ult().nom), cadena.primero().nCol);
                cadPila = pila.muestracontprod();
                cadCad = cadena.muestracontprod();
                if (accion != "")
                {
                    if (accion[0] == 'D')
                    {
                        linea = accion.Replace("Desplazar a ", "");
                        pila.nuevo(cadena.quitaPrimero());
                        pila.nuevo(new NT(linea));
                    }
                    if (accion[0] == 'R')
                    {
                        linea = accion.Replace("Reducir ", "");
                        row = int.Parse(linea);
                        ReduTemp = row;
                        accion += "   " + listaR[row].mostrarr() ;
                        if ((reducir(listaR[row], pila, tablaAS) == true))
                        {
                            
                            if (listaR[row].derecha[0].ltok[0].nom != "ε")
                            {
                                linea = buscacel(tablaAS, int.Parse(pila.ult().nom), listaR[row].ladoIzq.nCol);
                                pila.nuevo(listaR[row].ladoIzq);
                                pila.nuevo(new NT(linea));
                            }
                        }
                        else return false;
                    }
                }
                else return false;
                
                tabla.Rows.Add(cadPila, cadCad, accion, acciontrad);
            }
            return true;
        }

        public void Acciones(int NumRedu, string Valex)
        {
            switch(NumRedu)
            {
                case 3:
                    Esquema.Push("Sexo" + Valex);
                    acciontrad = "push ( " + Esquema.First() + " )";
                    break;
                case 4:
                    Esquema.Push("Sexo" + Valex);
                    acciontrad = "push ( " + Esquema.First() + " )";
                    break;
                case 12:
                    Esquema.Push("Presion" + Valex);
                    acciontrad = "push ( " + Esquema.First() + " )";
                    break;
                case 13:
                    Esquema.Push("Glucosa" + Valex);
                    acciontrad = "push ( " + Esquema.First() + " )";
                    break;
                case 14:
                    Esquema.Push("Trigliceridos" + Valex);
                    acciontrad = "push ( " + Esquema.First() + " )";
                    break;
                case 19:
                    Esquema.Push("Alimento" + Valex);
                    acciontrad = "push ( " + Esquema.First() + " )";
                    break;
                case 20:
                    Esquema.Push("Alimento" + Valex);
                    acciontrad = "push ( " + Esquema.First() + " )";
                    break;
                case 21:
                    Esquema.Push("Alimento" + Valex);
                    acciontrad = "push ( " + Esquema.First() + " )";
                    break;
                case 22:
                    Esquema.Push("Alimento" + Valex);
                    acciontrad = "push ( " + Esquema.First() + " )";
                    break;
                case 23:
                    Esquema.Push("Alimento" + Valex);
                    acciontrad = "push ( " + Esquema.First() + " )";
                    break;
                case 24:
                    Esquema.Push("Nombre" + Valex);
                    acciontrad = "push ( " + Esquema.First() + " )";
                    break;
                case 25:
                    Esquema.Push("Edad" + Valex);
                    acciontrad = "push ( " + Esquema.First() + " )";
                    break;
                case 26:
                    Esquema.Push("Peso" + Valex);
                    acciontrad = "push ( " + Esquema.First() + " )";
                    break;
                case 27:
                    Esquema.Push("Altura" + Valex);
                    acciontrad = "push ( " + Esquema.First() + " )";
                    break;
                case 29:
                    Esquema.Push("Actividad" + Valex);
                    acciontrad = "push ( " + Esquema.First() + " )";
                    break;
                case 30:
                    Esquema.Push("Actividad" + Valex);
                    acciontrad = "push ( " + Esquema.First() + " )";
                    break;
                case 31:
                    Esquema.Push("Actividad" + Valex);
                    acciontrad = "push ( " + Esquema.First() + " )";
                    break;
                case 32:
                    Esquema.Push("Actividad" + Valex);
                    acciontrad = "push ( " + Esquema.First() + " )";
                    break;
                case 33:
                    Esquema.Push("Diabetes" + Valex);
                    acciontrad = "push ( " + Esquema.First() + " )";
                    break;
                case 34:
                    Esquema.Push("Diabetes" + Valex);
                    acciontrad = "push ( " + Esquema.First() + " )";
                    break;
            }
        }
    }
}
