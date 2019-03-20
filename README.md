# ElectionKata
A shorthand feed with election results must be transformed into a user friendly statistical format

## Results format

```
	Given a short hand version of the election results
    As a polling analyst
    I want the election results converted to a specific format
```

The fields in the data input will be separated by commas but each row will vary in length as described below.

A result will consist of:

1. A constituency
2. A repeating set of pairs with the party code and the votes cast

So for example:

    Cardiff West, 11014, C, 17803, L, 4923, UKIP, 2069, LD
    Islington South & Finsbury, 22547, L, 9389, C, 4829, LD, 3375, UKIP, 3371, G, 309, Ind

We want to transform this into a standard result that shows:

* the constituency name
* translates the party code into a full name
* shows the share of the vote as a percentage of all the votes cast

For example:

    Cardiff West || Conservative Party | 30.76% || Labour Party | 49.72% || UKIP | 13.75% || Liberal Democrats | 5.78%
    Islington South & Finsbury || Labour Party | 51.45% || Conservative Party | 21.43% || Liberal Democrats | 11.02% || UKIP | 7.70% || Green Party | 7.69% || Independent | 0.70%

### Codes

* C - Conservative Party
* L - Labour Party
* UKIP - UKIP
* LD - Liberal Democrats
* G - Green Party
* Ind - Independent
* SNP - SNP

<div style="page-break-after: always;"></div>

## Larger Results Sample
```
Aldershot, 4445, LD, 26545, UKIP, 244, Ind, 3, SNP, 4, G, 3, C
Aldridge-Brownhills, 12703, G, 10543, L, 5327, Ind, 258, LD, 76, C, 67, UKIP
Altrincham and Sale West, 28667, G, 3372, SNP, 11372, L, 127, Ind, 13, LD, 381, UKIP
Amber Valley, 15242, C, 9295, UKIP, 8197, LD, 5474, Ind, 26, G, 269, L, 2336, SNP
Arundel and South Downs, 14939, SNP, 10117, UKIP, 3379, LD, 9137, Ind, 8699, G, 765, C, 1423, L
Ashfield, 2012, C, 5352, Ind, 2759, L, 31770, SNP, 1651, G, 138, LD, 53, UKIP
Ashford, 36165, SNP, 1477, LD, 7663, G, 2538, Ind, 1098, C
Ashton-under-Lyne, 20440, SNP, 16099, L, 1348, C, 6, UKIP, 4, G
Aylesbury, 26312, UKIP, 14437, Ind, 4646, SNP, 46, L, 784, LD
Banbury, 15440, L, 14671, C, 14842, G, 3615, SNP, 7590, UKIP
Barking, 10739, L, 27717, LD, 2061, SNP, 8334, Ind, 2752, C
Barnsley Central, 1804, L, 7745, G, 22535, SNP, 1944, LD, 8988, Ind
Barnsley East, 35886, LD, 4305, G, 2106, C, 1993, L
Barrow and Furness, 19552, SNP, 7020, UKIP, 1281, G, 16610, L
Basildon and Billericay, 32421, G, 7929, UKIP, 2072, C, 1833, Ind
Basingstoke, 33220, G, 17403, SNP, 1362, Ind, 413, UKIP
Bassetlaw, 26431, L, 541, G, 531, UKIP, 7052, SNP
Bath, 20347, L, 85, UKIP, 1101, LD, 3195, C, 137, Ind, 654, SNP, 1188, G
Batley and Spen, 15193, Ind, 2349, L, 13632, G, 50, C, 488, LD, 79, SNP, 270, UKIP
Battersea, 15031, UKIP, 525, LD, 22639, C, 255, Ind, 920, L, 934, SNP, 33, G
```

## .Net Core BDD Framework
[CoreBDD](https://github.com/stevenknox/CoreBDD)