// For more information see https://aka.ms/fsharp-console-apps

module Huffman =
    let assort lst1 count lst2 =
    let createHuffmanTable (bx : [byte]) : [(byte, int)] =
        [(1, 1)]
        where
            bx2 = List.sort bx

printfn "Hello from F#"
