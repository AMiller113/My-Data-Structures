package com.company;
import java.util.LinkedList;

public class Vertex<T, U> {
    private T value;
    private LinkedList<Edge<U, T>> incident_edges;

    public Vertex(T value) {
        this.value = value;
        incident_edges = new LinkedList<Edge<U, T>>();
    }

    public boolean isAdjacentTo(Vertex<T, U> vertex){
        for(Edge<U, T> edge:incident_edges){
            if (!edge.Opposite(vertex).equals(null)){
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

    public LinkedList<Edge<U, T>> getIncident_edges() {
        return incident_edges;
    }
}
