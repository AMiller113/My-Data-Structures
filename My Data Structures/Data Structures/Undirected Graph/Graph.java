package com.company;
import java.util.LinkedList;

public class Graph<T, U> {
    private LinkedList<Vertex<T, U>> vertex_list;
    private LinkedList<Edge<U, T>> edge_list;

    public Graph(LinkedList<Vertex<T, U>> vertex_list, LinkedList<Edge<U, T>> edge_list) {
        this.vertex_list = vertex_list;
        this.edge_list = edge_list;
    }

    public Graph(){
        vertex_list = new LinkedList<Vertex<T, U>>();
        edge_list = new LinkedList<Edge<U, T>>();
    }

    public LinkedList<Vertex<T, U>> getVertex_list() {
        return vertex_list;
    }

    public LinkedList<Edge<U, T>> getEdge_list() {
        return edge_list;
    }

    public void InsertVertex(T value){
        Vertex<T, U> newVertex = new Vertex<T, U>(value);
        vertex_list.add(newVertex);
    }

    public void InsertEdge(Vertex<T,U> endpoint1, Vertex<T, U> endpoint2, U value){
        LinkedList<Vertex<T,U>> endpoints = new LinkedList<Vertex<T, U>>();
        endpoints.add(endpoint1);
        endpoints.add(endpoint2);
        Edge<U, T> edge = new Edge<U, T>(value, endpoints);
        endpoint1.getIncident_edges().add(edge);
        endpoint2.getIncident_edges().add(edge);
        edge_list.add(edge);
    }

    public boolean EraseVertex(Vertex<T, U> vertex){
        if(!vertex_list.contains(vertex))
            return false;
        LinkedList<Edge<U, T>> incidentEdges = vertex.getIncident_edges();
        for(Edge<U, T> edge : incidentEdges){
            if(edge_list.contains(edge)){
                edge_list.remove(edge);
            }
        }
        vertex_list.remove(vertex);
        return true;
    }
}
