/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package day5;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;

/**
 *
 * @author tim
 */
public class BoardingPasses {
    
    public ArrayList<String> readPasses(String path){
        ArrayList<String> output = new ArrayList<String>();
        try {
              File file = new File(path);
              Scanner reader = new Scanner(file);
              while(reader.hasNextLine()){
                  String data = reader.nextLine();
                  output.add(data);
                  //System.out.println(data);
              }
              reader.close();
              System.out.println("Number of boarding passes read in:"
                                    + output.size());

        } catch (FileNotFoundException e) {
            System.out.println("An error occurred.");
            e.printStackTrace();
        }
        return output;
    }
    
    //F/B -> range of 0-127
    //Front -> lower half
    //back -> upper half of range
    //L/R -> range of 0-7
    //R-> Top half of range
    //L -> Lower half of range
    public int getRow(String rowCode){
        //Defines the range of rows
        int rowMax = 127;
        int rowMin = 0;
        int output = 0;
        //Get midpoint of rows
        //Redefine range to be above or below midpoint, based on F or B
        
        for(int i = 0; i < rowCode.length();i++){
            
            if(rowCode.charAt(i) == 'F'){
                rowMax = rowMax - ((rowMax - rowMin) / 2) - 1;
//                System.out.println("Lower half of range");
//                prntRange(rowMax, rowMin);
//                System.out.println("i is at: "  + i );
//                System.out.println("--------------------------");
            }
            else if(rowCode.charAt(i) == 'B'){
                rowMin = rowMin + ((rowMax - rowMin) / 2) + 1;
//                System.out.println("Upper  half of range");
//                prntRange(rowMax, rowMin);
//                System.out.println("i is at: "  + i );
//                System.out.println("-----------------------------");
            }
            if(i == 6)
            {
                output = rowMax;
            }
        }
        return output;
    }
    
    public int getCol(String colCode){
        int colMax = 7;
        int colMin = 0;
        int output = 0;
        for (int i = 0; i < colCode.length(); i++) {
            if(colCode.charAt(i) == 'L'){
                colMax = colMax - ((colMax - colMin) / 2) - 1;
            }else if(colCode.charAt(i) == 'R'){
                colMin = ((colMax -colMin)/2)+1;
            }
            if(i==2){
                output = colMax-1;
            }
        }
        return output;
    }
    private void prntRange(int max, int min){
        System.out.println("Max: " + max);
        System.out.println("Min: " + min);
    }
    
}
