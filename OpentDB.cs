using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Trabajo_Integrador
{
    /// <summary>
    /// Clase que obtiene y procesa los datos obtenidos en OpentDb para transformarlos en preguntas
    /// </summary>
    public class OpentDB : EstrategiaObtenerPreguntas
    {
        List<Pregunta> listaPreguntas = new List<Pregunta>();

        public OpentDB():base ("OpentDB")
        {

        }

        //metodo para obtener preguntas
        public override List<Pregunta> getPreguntas(string pCantidad, string pDificultad, string pCategoria)
        {
            {
                // Establecimiento del protocolo ssl de transporte
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                // Creacion de URL
                var mUrl =CrearURL(pCantidad,pDificultad,pCategoria);

                
                // Se crea el request http
                HttpWebRequest mRequest = (HttpWebRequest)WebRequest.Create(mUrl);

                try
                {
                    // Se ejecuta la consulta
                    WebResponse mResponse = mRequest.GetResponse();

                    // Se obtiene los datos de respuesta
                    using (Stream responseStream = mResponse.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);

                        // Se parsea la respuesta y se serializa a JSON a un objeto dynamic
                        dynamic mResponseJSON = JsonConvert.DeserializeObject(reader.ReadToEnd());

                        // Se iteran cada uno de los resultados.
                        foreach (var bResponseItem in mResponseJSON.results)
                        {
                            // De esta manera se accede a los componentes de cada item
                            string pregunta = bResponseItem.question.ToString();
                            string respuestaCorrecta = bResponseItem.correct_answer.ToString();
                            Categoria categoria = new Categoria(bResponseItem.category.ToString());
                            Dificultad dificultad = new Dificultad(bResponseItem.difficulty.ToString());
                            List<string> respIncorrectas = bResponseItem.incorrect_answers.ToObject<List<string>>();

                            Pregunta preg = new Pregunta(pregunta, respuestaCorrecta, respIncorrectas, dificultad, categoria);

                            //se agrega cada una de las preguntas a la lista

                            listaPreguntas.Add(preg);
                        }           
                    }
                }
                catch (WebException ex)
                {
                    WebResponse mErrorResponse = ex.Response;
                    using (Stream mResponseStream = mErrorResponse.GetResponseStream())
                    {
                        StreamReader mReader = new StreamReader(mResponseStream, Encoding.GetEncoding("utf-8"));
                        String mErrorText = mReader.ReadToEnd();

                        System.Console.WriteLine("Error: {0}", mErrorText);
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Error: {0}", ex.Message);
                }
                System.Console.ReadLine();
                return listaPreguntas;
            }
        }
        public string CrearURL(string pCantidad, string pDificultad, string pCategoria)
        {
            return ("https://opentdb.com/api.php?amount=" + pCantidad + "&category=" + pCategoria + "&difficulty=" + pDificultad + "&type=multiple");
        }
    }
}
