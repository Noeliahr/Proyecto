/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package termometro;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.io.Reader;
import java.io.UnsupportedEncodingException;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.ProtocolException;
import java.net.URL;
import java.net.URLEncoder;
import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.net.ssl.HttpsURLConnection;
import org.omg.CORBA.NameValuePair;

/**
 *
 * @author Noelia
 */
public class Termometro implements Runnable {
    
    private long siesta; // tiempo que duerme la hebra
    public Thread thr ; // objeto hebra encapsulado
    
    public Termometro( String nombre, long siesta ){ 
        this.siesta = siesta;
        thr = new Thread( this, nombre );
    }

    private static void simularTermometro(){
        try {

            URL url = new URL("http://localhost:21021/api/services/app/Recor/GetisRecordatorio");//your url i.e fetch data from .
            HttpURLConnection conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("GET");
            conn.setRequestProperty("Accept", "application/json");
            if (conn.getResponseCode() != 200) {
                throw new RuntimeException("Failed : HTTP Error code : "
                        + conn.getResponseCode());
            }
            InputStreamReader in = new InputStreamReader(conn.getInputStream());
            BufferedReader br = new BufferedReader(in);
            String output= br.readLine();
            int inicio = output.indexOf('[');
            int fin = output.indexOf("]");
            String cadena= output.substring(inicio+2, fin-1);
            System.out.println("Cadena vale " + cadena);
            if (!cadena.equals("null")) {
                //System.out.println(cadena);
                int isComa= cadena.indexOf(",");
                if (isComa>0){
                    String [] ids = cadena.split(",");
                    for (int i=0; i<ids.length; i++){
                        Termometro.generarTemperatura(Integer.parseInt(ids[i].replace("\"", "")));
                    }
                }else {
                    Termometro.generarTemperatura(Integer.parseInt(cadena.replace("\"", "")));
                }
            }
            conn.disconnect();

        } catch (Exception e) {
            //System.out.println("hola");
            System.out.println("Exception in NetClientGet:- " + e);
        }
    }

    private static void generarTemperatura(int id) {
        try {
            double temperatura= Math.random()*4 + 36;       
            
            URL url;
            url = new URL("http://localhost:21021/api/services/app/AddTemperatura/Add");
            Map<String, Object> params = new LinkedHashMap<>();
            
            params.put("idPaciente", id);
            params.put("temperatura", temperatura);
            
            StringBuilder postData = new StringBuilder();
            for (Map.Entry<String, Object> param : params.entrySet()) {
                if (postData.length() != 0)
                    postData.append('&');
                postData.append(URLEncoder.encode(param.getKey(), "UTF-8"));
                postData.append('=');
                postData.append(URLEncoder.encode(String.valueOf(param.getValue()),
                        "UTF-8"));
            }
            byte[] postDataBytes = postData.toString().getBytes("UTF-8");
            
            HttpURLConnection conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("POST");
            conn.setRequestProperty("Content-Type",
                    "application/x-www-form-urlencoded");
            conn.setRequestProperty("Content-Length",
                    String.valueOf(postDataBytes.length));
            conn.setDoOutput(true);
            conn.getOutputStream().write(postDataBytes);
            
            Reader in = new BufferedReader(new InputStreamReader(
                    conn.getInputStream(), "UTF-8"));
            for (int c = in.read(); c != -1; c = in.read())
                System.out.print((char) c);
            
           System.out.println("temperatura es " + temperatura);
            if (temperatura>38){
               System.out.println("Tiene fiebre");
               Termometro.Notificar(id, temperatura);
            }
        } catch (MalformedURLException ex) {
            Logger.getLogger(Termometro.class.getName()).log(Level.SEVERE, null, ex);
        } catch (UnsupportedEncodingException ex) {
            Logger.getLogger(Termometro.class.getName()).log(Level.SEVERE, null, ex);
        } catch (IOException ex) {
            Logger.getLogger(Termometro.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    private static void Notificar(int id, double temperatura) {
        try {

            URL url = new URL("http://localhost:21021/api/services/app/PersonasRelacionadas/getResponsables?id="+id);//your url i.e fetch data from .
            HttpURLConnection conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("GET");
            conn.setRequestProperty("Accept", "application/json");
            if (conn.getResponseCode() != 200) {
                throw new RuntimeException("Failed : HTTP Error code : "
                        + conn.getResponseCode());
            }
            InputStreamReader in = new InputStreamReader(conn.getInputStream());
            BufferedReader br = new BufferedReader(in);
            
            String output= br.readLine();
            int inicio = output.indexOf('[');
            int fin = output.indexOf("]");
            String cadena= output.substring(inicio+2, fin-1);
            if (cadena  != null) {
                //System.out.println(cadena);
                int isComa= cadena.indexOf(",");
                if (isComa>0){
                    String [] users = cadena.split(",");
                    String u= users[0].replace("\"", "");
                    String texto= u + " tiene " + temperatura + "ºC";
                    for (int i=1; i<users.length; i++){
                        System.out.println("Vamos a mandar el mensaje: " + users[i].replace("\"", "") + " " + texto);
                        Termometro.mandarMensaje(users[i].replace("\"", ""), texto);  
                    }
                }
            }
            conn.disconnect();

        } catch (Exception e) {
            System.out.println("Exception in NetClientGet:- " + e);
        }
    }

    private static void mandarMensaje(String persona, String texto) {
        try {
            URL url;
            url = new URL("http://localhost:21021/api/services/app/MandarFiebre/Notificar");
            Map<String, Object> params = new LinkedHashMap<>();
            
            params.put("personaDestino", persona);
            params.put("texto", texto);
            
            StringBuilder postData = new StringBuilder();
            for (Map.Entry<String, Object> param : params.entrySet()) {
                if (postData.length() != 0)
                    postData.append('&');
                postData.append(URLEncoder.encode(param.getKey(), "UTF-8"));
                postData.append('=');
                postData.append(URLEncoder.encode(String.valueOf(param.getValue()),
                        "UTF-8"));
            }
            byte[] postDataBytes = postData.toString().getBytes("UTF-8");
            
            HttpURLConnection conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("POST");
            conn.setRequestProperty("Content-Type",
                    "application/x-www-form-urlencoded");
            conn.setRequestProperty("Content-Length",
                    String.valueOf(postDataBytes.length));
            conn.setDoOutput(true);
            conn.getOutputStream().write(postDataBytes);
            
            Reader in = new BufferedReader(new InputStreamReader(
                    conn.getInputStream(), "UTF-8"));
            for (int c = in.read(); c != -1; c = in.read())
                System.out.print((char) c);
            
        } catch (MalformedURLException ex) {
            Logger.getLogger(Termometro.class.getName()).log(Level.SEVERE, null, ex);
        } catch (UnsupportedEncodingException ex) {
            Logger.getLogger(Termometro.class.getName()).log(Level.SEVERE, null, ex);
        } catch (IOException ex) {
            Logger.getLogger(Termometro.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    @Override
    public void run() {
        
        try{ 
            while ( true ){ 
                Termometro.simularTermometro();
                if ( siesta > 0 ) {
                    System.out.println("Voy a dormir ");
                    Thread.sleep( siesta );
                }
            }
        }catch ( InterruptedException e ){ 
            System.out.println( "me fastidiaron la siesta!" );
        }
        
    }
    
}
