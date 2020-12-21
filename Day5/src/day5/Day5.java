/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package day5;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;
import java.util.ArrayList;

/**
 *
 * @author tim
 */
public class Day5 {

    /**
     * @param args the command line arguments
     */
    
    public static void main(String[] args) {
        // TODO code application logic here
        BoardingPasses processor = new BoardingPasses();
        final String PATH = "C:\\Users\\tim\\repos\\AdventOfCode\\Day5\\src\\day5\\input.txt";
        ArrayList<String> boardingPasses;
        
        boardingPasses = processor.readPasses(PATH);
        long highestId = 0;
        for(int i = 0; i<boardingPasses.size(); i++){
            //firstSubstring : FBBFBBB
            //BFFFBBFRRR
            String sRow = boardingPasses.get(i).substring(0,7);
            String sCol = boardingPasses.get(i).substring(7,10);
            //BBFBFBBRRR
            int row = processor.getRow(sRow);
            int col = processor.getCol(sCol);
            
            long id = (row*8)+col;
            System.out.println("Id: " + id);
            if(id > highestId){
                highestId = id;
            }
            
        }
        System.out.println(highestId);
        
    }
    
    

}
