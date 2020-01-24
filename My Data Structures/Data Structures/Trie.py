class TrieNode:
    def __init__(self, alphabet, char):
        self.alphabet = alphabet  # The alphabet is a dictionary that can will have keys that tell us if a particular
        # character has been used at that junction
        self.char = char  # The node will contain the character for concatenation while searching


# String based trie
class Trie:
    def __init__(self, string_set):
        self.stringSet = string_set  # The large set S of strings
        self.alphabet = self.get_alphabet()  # To generate the alphabet of the trie
        self.root = TrieNode(self.alphabet, None)  # Initializing the root node with the alphabet and a null value
        self.construct_trie()

    # Will use each char in the string as keys, since keys are unique we automatically avoid duplicates
    def get_alphabet(self):
        _alphabet = {}
        for char in self.stringSet:
            _alphabet[char] = None
        return _alphabet
        pass

    # Will use a dictionary in each node whose keys are the alphabet and whose values are either none or the next
    # node in the path
    def construct_trie(self):
        _split = self.stringSet.split()
        _root = self.root
        for string in _split:
            _root = self.root  # Every subsequent string begins at the root
            for char in string:
                _root.alphabet[char] = TrieNode(self.alphabet, char)
                _root = _root.alphabet[char]
        pass

    # Trace a path through each nodes dictionary
    def search(self, search_string):
        _root = self.root
        for char in search_string:
            if _root.alphabet[char] is None:
                return False
            _root = _root.alphabet[char]
        return True
        pass
