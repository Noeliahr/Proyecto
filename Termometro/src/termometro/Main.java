/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package termometro;

/**
 *
 * @author Noelia
 */
public class Main {
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws InterruptedException {
        // TODO code application logic here
        long siesta = 300000;
        Termometro obj = new Termometro("Termometro", siesta); // crear hebra
        obj.thr.start(); // lanzar hebra
        Thread.sleep(100); // la hebra principal duerme 1/10 sec.
        obj.thr.join();
    }
}
