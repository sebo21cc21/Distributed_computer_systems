import io.grpc.ManagedChannel;
import io.grpc.ManagedChannelBuilder;

public class  GrpcClient {
    public static void main(String[] args) {
        String address = "localhost";
        int port = 50001;
        System.out.println("Running grpc client...");
        ManagedChannel channel = ManagedChannelBuilder.forAddress(address, port) .usePlaintext()
                .build();
        GrpcServiceGrpc.GrpcServiceBlockingStub stub = GrpcServiceGrpc.newBlockingStub(channel);
        GrpcRequest request = GrpcRequest.newBuilder() .setName("Mateusz")
                .setAge(21)
                .build();
        GrpcResponse response = stub.grpcProcedure(request);
        System.out.println(response);
        channel.shutdown();
    }
}