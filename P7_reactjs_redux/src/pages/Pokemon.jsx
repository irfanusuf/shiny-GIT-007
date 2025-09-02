import { pokemonApi, useGetPokemonByNameQuery } from "../redux/api/pokemonApi"



const Pokemon = () => {




    // const { data, isLoading, error } = pokemonApi.endpoints.getPokemonByName.useQuery("bulbasaur")   

    const { data, isLoading, error } = useGetPokemonByNameQuery('jigglypuff')




    return (
        <div>


            <h1 style={{ textAlign: "center" }}> Pokemon API Demo </h1>


            <p style={{ textAlign: "center" }}>  {isLoading ? "POKEMON  DATA LOADING... " : "Data fetched succesfully !"} </p>

            <p style={{ textAlign: "center", color: "red" }} > {error && error.message}  </p>


            <div style={{display : "flex" , flexDirection : "column" ,  margin : "auto"  , width : "50%"}}>


                <div style={{display : "flex" , alignItems : "center"}}  >
                    <h2> {data && data.species.name.toUpperCase()} </h2>

                    <img src={data && data.sprites.front_default} />

                    <img src={data && data.sprites.front_shiny} />


                    {/* <img src={data && data.sprites} /> */}
                </div>



                <p> Weight : <span> {data && data.weight} kg </span> </p> 
                 <p> height : <span> {data && data.height} ft </span> </p> 


                <div>
                   <h2> Total Fighting Moves  <span>   {data && data.moves.length } </span> </h2> 

                   {data && data.moves.map((move) => (<div> {move.move.name}  </div>))}
                   


                </div>



            </div>






        </div>
    )
}

export default Pokemon