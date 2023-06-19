import sys
import json
from difflib import SequenceMatcher

def compare_sensitive_values(dict1, dict2, attribute, generalization_hierarchy):

  value1 = dict1.get(attribute)
  value2 = dict2.get(attribute)

  if value1 is None or value2 is None:
    return 0

  # Find the generalization level for each value based on the hierarchy.
  gen_level1 = None
  gen_level2 = None
  for i, level in enumerate(generalization_hierarchy):
    if value1 in level:
      gen_level1 = i
    if value2 in level:
      gen_level2 = i
    if gen_level1 is not None and gen_level2 is not None:
      break

  # If both values are in the same level, use exact match comparison.
  if gen_level1 == gen_level2:
    return SequenceMatcher(None, value1, value2).ratio()

  # Otherwise, return 0 to indicate no match.
  return 0

def generalize_sensitive_values(data, attribute, generalization_hierarchy):

  # Create a copy of the data.
  anonymized_data = data.copy()

  # Generalize the sensitive attribute in each record based on the hierarchy.
  for record in anonymized_data:
    value = record.get(attribute)
    if value is not None:
      for level in generalization_hierarchy:
        if value in level:
          record[attribute] = level[0]  # Replace the value with the lower bound of the range.
          break

  return anonymized_data

def t_closeness(data, t, attribute, generalization_hierarchy):

    # Generalize the sensitive attribute values in the data.
    anonymized_data = generalize_sensitive_values(data, attribute, generalization_hierarchy)

    # Calculate the pairwise similarities between the generalized sensitive attribute values.
    similarities = {}
    calcsimilar={}
    nameattribute="namee"
    for i, record1 in enumerate(anonymized_data):
        for j, record2 in enumerate(anonymized_data):
            if i != j and record1[attribute] != record2[attribute]:
                similarity = compare_sensitive_values(record1, record2, attribute,generalization_hierarchy)
                similarities[(i, j)] = similarity
                name1= anonymized_data[i].get(nameattribute)
                name2= anonymized_data[j].get(nameattribute)
                # Calculate the t-closeness metric as 1 minus the maximum pairwise similarity.
                t_closeness = 1 - max(similarities.values())
                calcsimilar.update({str((name1,name2)): t_closeness})

    
  

    # Return the anonymized data and the t-closeness value.
    return anonymized_data, calcsimilar


if __name__ == "__main__":
  # Read the data from a JSON file.
    data = json.load(open(sys.argv[2]))

    # Set the threshold for similarity.
    t = 0.5

    # Set the sensitive attribute and the generalization hierarchy.
    attribute = "fakeObject"
    generalization_hierarchy = [["a", "b", "c"], ["d", "e", "f"], ["g", "h", "i"], ["j", "k", "l"], ["m", "n", "o"], ["p", "q", "r"], ["s", "t", "u"], ["v", "w", "x"], ["y", "z"]]

    # Calculate the t-closeness value for the data.
    anonymized_data, result = t_closeness(data, t, attribute, generalization_hierarchy)

    with open(sys.argv[3], "w") as f:
      json.dump(result, f, indent=2)
  


 

