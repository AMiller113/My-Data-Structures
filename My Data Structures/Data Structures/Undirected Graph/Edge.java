package com.company;
import java.util.LinkedList;


public class Edge<T, U> {
    private T value;
    private final LinkedList<Vertex<U, T>> endpoints;

    public Vertex<U, T> Opposite(Vertex<U, T > v){
        if (endpoints.contains(v)){
            for (Vertex<U, T> u: endpoints) {
                if (u.equals(v)){
                    continue;
                }
                else{
                    return u;
                }
            }
        }
        return null;
    }

    public boolean isAdjacentTo(Edge<T, U> edge){
        for(Vertex<U, T> vertex: endpoints){
            if(edge.endpoints.contains(vertex)){
                return true;
            }
        }
        return false;
    }

    public T getValue() {
        return value;
    }

    public void setValue(T value) {
        this.value = value;
    }

    public LinkedList<Vertex<U, T>> getEndpoints() {
        return endpoints;
    }

    public Edge(T value, LinkedList<Vertex<U, T>> endpoints) {
        this.value = value;
        this.endpoints = endpoints;
    }
}
