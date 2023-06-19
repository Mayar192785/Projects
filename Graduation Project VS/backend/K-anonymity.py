import json
from itertools import combinations
import sys
k = 5
quasi_identifiers = ['img']

with open("args.json") as f:
    data = json.load(f)

partitions = []

def anonymize(partition):
    for record in partition:                          
        record['img']['contentType'] = 'text'  

def similar_combo(combo, record):   
    return all(type(combo[i]) == type(record[field])  
           for i, field in enumerate(quasi_identifiers))

def create_partition(combo):       
    partition = []    
   
    for record in data:  
        if similar_combo(combo, record):   
            partition.append(record) 
                   
    return partition    
all_combos = combinations([record[field] for record in data for field in quasi_identifiers], len(quasi_identifiers))
anonymy ={}
for combo in all_combos:   
    partition = create_partition(combo) 
    anonymy.update({(str(combo)):combo.__len__()})  
    if len(partition) >= k:
       anonymize(partition)
       partitions.append(partition)

for partition in partitions:       
    anonymize(partition)        

for partition in partitions:   
    assert len(set(tuple(p.values() for p in partition))) >= k 
    

with open("bar.json", 'w') as f:   
    json.dump(anonymy, f, indent=2) 

with open("r.json", 'w') as f:   
    json.dump(data, f, indent=2)    
