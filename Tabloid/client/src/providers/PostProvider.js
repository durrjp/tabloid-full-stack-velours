import React, { useState, useContext } from "react";
import { UserProfileContext } from "./UserProfileProvider";

export const PostContext = React.createContext();

export const PostProvider = (props) => {
    const [posts, setPosts] = useState([]);
    const [cuPosts, setCUPosts] = useState([]);
    const { getToken } = useContext(UserProfileContext);
    
    const getAllPosts = () => {
        getToken().then((token) => 
        fetch("/api/post", {
          method: "GET",
          headers: {
            Authorization:  `Bearer ${token}`
          }
        }).then((res) => res.json())
          .then(setPosts));
      }
      const getUserPosts = () => (
        getToken().then((token) =>
        fetch(`/api/myposts`, {
          method: "GET",
          headers: {
            Authorization:  `Bearer ${token}`
          }
          }))
            .then((res) => res.json())
            .then(setCUPosts)  
      )
    
    return (
    <PostContext.Provider value={{ posts, getAllPosts, getUserPosts, cuPosts}}>
        {props.children}
    </PostContext.Provider>
    );
}